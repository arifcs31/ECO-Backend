using ExcelDataReader;
using Shopex.Application.Interfaces;
using Shopex.Domain.Feed;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Infrastructure.FeedTransformer
{
    public class ProductsFeedTransformer : BaseFeedTransformer, IFeedProductTransformer
    {
        public async Task<IEnumerable<ProductFeedModel>> TransformProducts(FileStream stream)
        {
            List<ProductFeedModel> list = new List<ProductFeedModel>();
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {

                var rowCount = 0;
                do
                {
                    while (reader.Read())
                    {
                        if (rowCount == 0) // to check if user has ignore header and put valid data.
                        {
                            if (CheckIfHeaderOfFile(reader.GetString(0)))
                            {
                                rowCount = 1;
                                continue;
                            }
                        }
                        try
                        {
                            if (!string.IsNullOrEmpty(reader.GetString(0)))

                                list.Add(ConvertRow(rowCount, reader));
                        }
                        catch(Exception err)
                        {
                            if (reader.GetDouble(0) != null)

                                list.Add(ConvertRow(rowCount, reader));
                        }
                        rowCount++;
                    }
                } while (reader.NextResult());

            }
            return await Task.Run(() => { return list; });
        }
        public ProductFeedModel ConvertRow(int rowCount, IExcelDataReader reader)
        {
            try
            {
                var model = new ProductFeedModel();
                try
                {
                    model.category_id = reader.GetValue(0)?.ToString();
                    model.brand = reader.GetValue(1)?.ToString();
                    model.upc = reader.GetValue(2)?.ToString();
                    model.product_id = reader.GetValue(2)?.ToString();
                }
                catch(Exception err)
                {
                    model.upc = reader.GetValue(2)?.ToString();
                    model.product_id = reader.GetValue(2)?.ToString();
                }
                
                model.name = reader.GetString(3);
                model.description = reader.GetString(4);
                model.tech_description = reader.GetString(5);
                model.uses = reader.GetValue(6)?.ToString();
                model.is_active = reader.GetValue(7)?.ToString() == "1" ? true : false;
                model.show_on_landing = reader.GetValue(8)?.ToString() == "1" ? true : false;
                model.sort = reader.GetValue(9)?.ToString();
                model.link_upc = reader.GetValue(10)?.ToString();
                return model;
            }
            catch(Exception err)
            {
                Console.WriteLine($"row = {rowCount},{err}");
                throw err;
            }
        }

        public Task<IEnumerable<CategoryFeedModel>> TransformCategory(FileStream stream)
        {
            throw new NotImplementedException();
        }

    }
}
