using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NLog.Common;
using System.IO;
using Science_searcher.Model;

namespace Science_searcher.Logic
{
    public class Downloader
    {
        public WebClient client;

        public Downloader(){}

        public void AddSeedToDb(string urlSeed)
        {
            TUrlsToProcess seedUrl = new TUrlsToProcess();
            seedUrl.ParentUrl = "This is root url";
            seedUrl.NewUrl = urlSeed;
            try
            {
                using (var dbContext = new ScienceDatastoreDBContext())
                {
                    dbContext.Add(seedUrl);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<string> GetDataFromHtml(string url)
        {
            string context = String.Empty;
            client = new WebClient();
            Task<string> content = client.DownloadStringTaskAsync(url);
            context = await content;
            return context;
        }

        public async Task WriteDataToDatabaseAndFileAsync()
        {
            string url = String.Empty;
            int url_Id = 1;
            using (var dbContext = new ScienceDatastoreDBContext())
            {
                var items = dbContext.TUrlsToProcess.OrderByDescending(p => new { p.Id, p.NewUrl }).Take(1).ToArray();
                url = items[0].NewUrl.ToString();
                url_Id = Convert.ToInt32(items[0].Id);
                TUrlsToProcess deleteUrl = new TUrlsToProcess() { Id = url_Id, NewUrl = url };
                TProcessedUrl processedUrl = new TProcessedUrl() { ProcessedUrl = url };
                dbContext.Entry(deleteUrl).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                dbContext.TProcessedUrl.Add(processedUrl);
                dbContext.SaveChanges();
            }
            string context = await DownloadPageContext(url);
            string fileName = SaveContentToFile(context);
            TOutputFiles outputFiles = new TOutputFiles();
            outputFiles.SourceUrl = url;
            outputFiles.FileName = fileName;

            //Write data to file and links to database
            using (var ctx = new ScienceDatastoreDBContext())
            {
                List<string> outgoingLinks = new List<string>();
                outgoingLinks = LinkExtractor.Find(context);
                List<TUrlsToProcess> outgoingLinkList = new List<TUrlsToProcess>();
                foreach (var link in outgoingLinks)
                {
                    TUrlsToProcess outgoingLink = new TUrlsToProcess() { ParentUrl = url, NewUrl = link };
                    outgoingLinkList.Add(outgoingLink);
                }
                ctx.TUrlsToProcess.AddRange(outgoingLinkList);
                ctx.TOutputFiles.Add(outputFiles);
                ctx.SaveChanges();
            }
        }

        private string SaveContentToFile(string context)
        {
            string startupPath = Environment.CurrentDirectory;
            string pageContentDirectory = System.IO.Path.Combine(startupPath, "PageContents");
            string filename = DateTime.Now.ToString() + "_" + RandomString(40) + ".txt";
            string filePathCombine = Path.Combine(pageContentDirectory,filename);
            if (!File.Exists(filePathCombine))
                File.WriteAllText(filePathCombine, context);
            return filename;
        }

        public async Task<string> DownloadPageContext(string url)
        {
            string pageContext = String.Empty;
            try
            {
                WebClient webClient = new WebClient();
                pageContext = await webClient.DownloadStringTaskAsync(url);
            }
            catch(Exception ex)
            {
                throw new Exception("Error occured when trying to download content from url.", ex.InnerException);
            } 
            return pageContext;
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
