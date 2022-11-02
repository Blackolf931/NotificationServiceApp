using BLL.Interfaces;

namespace BLL.Services
{
    public class GenericService<TModel> : IGenericService<TModel>
    {
        public virtual Task SendNotification(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
