using Microsoft.EntityFrameworkCore;

namespace WebAPIAutores.Utilidades
{
    public static class HttpContextEntensions
    {
        public async static Task InsertarParametrosPaginacionEnCabecera<T>(this HttpContext context, IQueryable<T> queryable)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }

            double cantidad = await queryable.CountAsync();

            context.Response.Headers.Add("cantidadTotalRegistros", cantidad.ToString());
        }
    }
}
