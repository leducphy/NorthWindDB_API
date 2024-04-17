using NorthWindDB.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using NorthWindDB.DTO;

namespace NorthWindDB.Formatter {
    public class CsvOutputFormatter :TextOutputFormatter {
        public CsvOutputFormatter() {
            SupportedMediaTypes.Add("text/csv");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type) {
            if (type == typeof(Product)) {
                return true;
            } else {
                Type enumerableType = typeof(IEnumerable<Product>);
                return enumerableType.IsAssignableFrom(type);
            }
        }

        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context,Encoding selectedEncoding) {
            var httpContext = context.HttpContext;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<ProductDTO> products) {
                foreach (var product in products) {
                    FormatCSV(buffer,product);
                }
            } else {
                FormatCSV(buffer,(ProductDTO)context.Object!);
            }

            await httpContext.Response.WriteAsync(buffer.ToString(),selectedEncoding);
        }

        private void FormatCSV(StringBuilder buffer,ProductDTO contact) {
            buffer.Append($"{contact.ProductId};");
            buffer.Append($"{contact.ProductName};");
            buffer.Append($"{contact.CategoryId};");
            buffer.Append($"{contact.UnitPrice}");
            buffer.Append($"{contact.SupplierId}");
            buffer.Append($"{contact.SupplierName}");
            buffer.Append($"{contact.TotalUnitSaled}");
            buffer.AppendLine();

        }
    }
}
