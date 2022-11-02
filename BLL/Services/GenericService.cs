using BLL.Interfaces;

namespace BLL.Services
{
    public class GenericService<TModel> : IGenericService<TModel> where TModel : class
    {
        public virtual Task SendNotification(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
