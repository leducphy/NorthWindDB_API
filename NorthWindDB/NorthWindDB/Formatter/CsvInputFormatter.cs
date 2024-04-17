using NorthWindDB.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using NorthWindDB.DTO;

namespace NorthWindDB.Formatter
{
    public class CsvInputFormatter : TextInputFormatter
    {
        public CsvInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(Product);
        }

        public async override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context,
            Encoding encoding)
        {
            var httpContext = context.HttpContext;
            using var reader = new StreamReader(httpContext.Request.Body, encoding);
            string? dataLine = null;
            try
            {
                await ReadLineAsync(
                    $"ProductName,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder, ReorderLevel, Discontinued, CategoryID",
                    reader, context);
                dataLine = await ReadLineAsync(null, reader, context);
                var data = dataLine.Split(',');
                var product = new AddProductDTO()
                {
                    ProductName = data[1],
                    QuantityPerUnit = data[2],
                    UnitPrice = Convert.ToDecimal(data[3]),
                    UnitsInStock = Convert.ToSByte(data[4]),
                    UnitsOnOrder = Convert.ToSByte(data[5]),
                    ReorderLevel = Convert.ToSByte(data[4]),
                    Discontinued = Convert.ToBoolean(data[5]),
                    CategoryID = Convert.ToInt32(data[2]),
                };

                return await InputFormatterResult.SuccessAsync(product);
            }
            catch (Exception)
            {
                return await InputFormatterResult.FailureAsync();
            }
        }

        private static async Task<string> ReadLineAsync(
            string expectedText, StreamReader reader, InputFormatterContext context)
        {
            var line = await reader.ReadLineAsync();

            if (expectedText != null)
            {
                if (line is null || !line.StartsWith(expectedText))
                {
                    var errorMessage = $"Looked for '{expectedText}' and got '{line}'";

                    context.ModelState.TryAddModelError(context.ModelName, errorMessage);


                    throw new Exception(errorMessage);
                }
            }


            return line;
        }
    }
}