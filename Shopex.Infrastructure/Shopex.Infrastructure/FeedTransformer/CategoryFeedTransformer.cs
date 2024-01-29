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
    public class CategoryFeedTransformer : BaseFeedTransformer, IFeedTransformer
    {
        public async Task<IEnumerable<CategoryFeedModel>> TransformCategory(FileStream stream)
        {
            List<CategoryFeedModel> list = new List<CategoryFeedModel>();
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
        public CategoryFeedModel ConvertRow(int rowCount, IExcelDataReader reader)
        {
            try
            {
                var model = new CategoryFeedModel();
                try
                {
                    model.category_id = reader.GetString(0);
                }
                catch(Exception err)
                {
                    model.category_id = reader.GetDouble(0).ToString();
                }
                try
                {
                    model.parent_id = reader.GetString(1);
                }
                catch (Exception err)
                {
                    model.parent_id = reader.GetDouble(1).ToString();
                }
                model.name = reader.GetValue(2).ToString();
                model.description = reader.GetValue(3)?.ToString();
                model.status = reader.GetValue(4)?.ToString() == "1" ? true : false;
                model.sort = reader.GetValue(5) != null ? Convert.ToInt16(reader.GetValue(5)?.ToString()?.Trim()) : 0;
                return model;
            }
            catch(Exception err)
            {
                Console.WriteLine($"row = {rowCount},{err}");
                throw err;
            }
        }

        public Task<IEnumerable<ProductFeedModel>> TransformProducts(FileStream stream)
        {
            throw new NotImplementedException();
        }
    }
}
