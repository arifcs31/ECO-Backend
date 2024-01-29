using ExcelDataReader;
using Shopex.Application.Interfaces;
using Shopex.Domain.Feed;

namespace Shopex.Infrastructure.FeedTransformer
{
    public class ProductPricesFeedTransformer : BaseFeedTransformer, IFeedProductPriceTransformer
    {
        public async Task<IEnumerable<ProductPriceFeedModel>> TransformProductPrices(FileStream stream)
        {
            List<ProductPriceFeedModel> list = new List<ProductPriceFeedModel>();
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
        public ProductPriceFeedModel ConvertRow(int rowCount, IExcelDataReader reader)
        {
            try
            {
                var model = new ProductPriceFeedModel();
                try
                {
                    model.upc = reader.GetValue(0)?.ToString();
                    model.size1 = reader.GetValue(1)?.ToString();
                    model.size2 = reader.GetValue(2)?.ToString();
                    model.pack_range = reader.GetValue(3)?.ToString();
                    model.price = reader.GetValue(4)?.ToString();
                    model.is_active = reader.GetValue(5)?.ToString() == "1" ? true : false;
                }
                catch(Exception err)
                {
                }
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
