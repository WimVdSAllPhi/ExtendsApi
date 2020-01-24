using ExtendsApi.Models;
using ExtendsApi.Models.DTO;
using System.Linq;

namespace ExtendsApi.Methods
{
    public static class OrderList<T> where T : class
    {
        public static IQueryable<T> Order(IQueryable<T> querable, OrderExtention orderExtention)
        {
            if (orderExtention == null || string.IsNullOrWhiteSpace(orderExtention.Property))
            {
                return querable;
            }

            if (querable == null || querable.Count() <= 0)
            {
                return null;
            }
            var property = orderExtention.Property;

            if (orderExtention.OrderBy == OrderBy.Ascending)
            {
                var prop = typeof(T).GetProperty(property);
                querable = querable.OrderBy(x => prop.GetValue(x, null)).ToList().AsQueryable();
            }
            else
            {
                var prop = typeof(T).GetProperty(property);
                querable = querable.OrderByDescending(x => prop.GetValue(x, null)).ToList().AsQueryable();
            }

            return querable;
        }
    }
}
