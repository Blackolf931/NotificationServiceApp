using BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace BackgroundService
{
    public class DataJob : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public DataJob(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var filesCollector = scope.ServiceProvider.GetService<IFilesCollector>();

                await filesCollector.StartCollector();
            }
        }
    }
}
