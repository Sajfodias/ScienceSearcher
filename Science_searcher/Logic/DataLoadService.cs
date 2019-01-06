using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Science_searcher.Logic
{
    public class DataLoadService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Downloader downloader = new Downloader();
            
            while (!cancellationToken.IsCancellationRequested)
            {
                await downloader.WriteDataToDatabaseAndFileAsync();
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }
    }
}
