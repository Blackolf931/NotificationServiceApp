using BLL.Interfaces;
using Quartz;

namespace BackgroundService
{
    public class DataJob : IJob
    {
        private readonly IFilesCollector serviceScopeFactory;

        public DataJob(IFilesCollector serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await serviceScopeFactory.StartCollector();
        }
    }
}
