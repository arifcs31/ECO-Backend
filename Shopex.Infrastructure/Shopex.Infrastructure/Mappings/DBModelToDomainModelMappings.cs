using Shopex.Domain.Model;
using Shopex.Infrastructure.DB.Model;
using Address = Shopex.Infrastructure.DB.Model.Address;
using Banners = Shopex.Infrastructure.DB.Model.Banners;
using Carts = Shopex.Infrastructure.DB.Model.Carts;
using Categories = Shopex.Infrastructure.DB.Model.Categories;
using DeliveryFees = Shopex.Infrastructure.DB.Model.DeliveryFees;
using ProductPrices = Shopex.Infrastructure.DB.Model.Product_Prices;
using Products = Shopex.Infrastructure.DB.Model.Products;
using Sessions = Shopex.Infrastructure.DB.Model.Sessions;
using Users = Shopex.Infrastructure.DB.Model.Users;

namespace Shopex.Infrastructure.Mappings
{
    public static class DBModelToDomainModelMappings
    {
        public static Shopex.Domain.Model.Banners ToDomainModel(this Banners banner, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return new Shopex.Domain.Model.Banners()
            {
                banner_id = banner.banner_id,
                title = banner.title,
                alt_desc = banner.alt_desc,
                created = banner.created,
                description = banner.description,
                end_time = banner.end_time,
                image_url = $"{imageUrl}/banner/{banner.banner_id}.jpg",
                is_active = banner.is_active,
                link_to = banner.link_to,
                placement = banner.placement,
                slug = banner.slug,
                start_time = banner.start_time,
                type = banner.type,
                updated = banner.updated
            };
        }
        public static Shopex.Domain.Model.Address ToDomainModel(this Address banner, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return new Shopex.Domain.Model.Address()
            {
                address_id = banner.address_id,
                company_name = banner.company_name,
                contact_name = banner.contact_name,
                country = banner.country,
                created = banner.created,
                phone = banner.phone,
                post_code = banner.post_code,
                reference = banner.reference,
                region = banner.region,
                town = banner.town,
                user_id = banner.user_id,
                address = banner.address,
                is_active = banner.is_active,
                updated = banner.updated,
                type = banner.type
            };
        }
        public static IEnumerable<Shopex.Domain.Model.Address> ToDomainModel(this IEnumerable<Address> address, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return address.Select(banner => new Shopex.Domain.Model.Address()
            {
                address_id = banner.address_id,
                company_name = banner.company_name,
                contact_name = banner.contact_name,
                country = banner.country,
                created = banner.created,
                phone = banner.phone,
                post_code = banner.post_code,
                reference = banner.reference,
                region = banner.region,
                address = banner.address,
                town = banner.town,
                user_id = banner.user_id,
                is_active = banner.is_active,
                updated = banner.updated,
                type =  banner.type
            });
        }
        public static Shopex.Domain.Model.OrderLines ToDomainModel(this Shopex.Infrastructure.DB.Model.Order_Lines orderLine, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return new Shopex.Domain.Model.OrderLines()
            {
                order_id = orderLine.order_id,
                order_line_id = orderLine.order_line_id,
                price = orderLine.price,
                product_id = orderLine.product_id,
                created = orderLine.created,
                product_price_id = orderLine.product_price_id,
                qty = orderLine.qty,
                product = orderLine.product.ToDomainModel(imageUrl),
                productPrice = orderLine.productPrice.ToDomainModel(),
                is_active = orderLine.is_active,
                total_price = orderLine.price * orderLine.count,
                updated = orderLine.updated,
                count = orderLine.count
            };
        }
        public static IEnumerable<Shopex.Domain.Model.OrderLines> ToDomainModel(this IEnumerable<Shopex.Infrastructure.DB.Model.Order_Lines> address, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return address.Select(orderLine => new Shopex.Domain.Model.OrderLines()
            {
                order_id = orderLine.order_id,
                order_line_id = orderLine.order_line_id,
                price = orderLine.price,
                product_id = orderLine.product_id,
                created = orderLine.created,
                product_price_id = orderLine.product_price_id,
                qty = orderLine.qty,
                product = orderLine.product.ToDomainModel(imageUrl),
                productPrice = orderLine.productPrice.ToDomainModel(),
                is_active = orderLine.is_active,
                total_price = orderLine.price * orderLine.count,
                updated = orderLine.updated,
                count = orderLine.count
            });
        }

        public static Shopex.Domain.Model.Orders ToDomainModel(this Shopex.Infrastructure.DB.Model.Orders orderLine, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return new Shopex.Domain.Model.Orders()
            {
                order_id = orderLine.order_id,
                address_id = orderLine.address_id,
                delivery_fee = orderLine.delivery_fee,
                created = orderLine.created,
                payment_reference = orderLine.payment_reference,
                note = orderLine.note,
                status = orderLine.status,
                sub_total = orderLine.sub_total,
                total = orderLine.total,
                total_tax = orderLine.total_tax,
                user_id = orderLine.user_id,
                user = orderLine.user.ToDomainModel(),
                orderLines = orderLine?.orderLines?.ToDomainModel(),
                is_active = orderLine.is_active,
                updated = orderLine.updated,
                address = orderLine.address.ToDomainModel(),
            };
        }
        public static IEnumerable<Shopex.Domain.Model.Orders> ToDomainModel(this IEnumerable<Shopex.Infrastructure.DB.Model.Orders> address, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return address.Select(orderLine => new Shopex.Domain.Model.Orders()
            {
                order_id = orderLine.order_id,
                address_id = orderLine.address_id,
                delivery_fee = orderLine.delivery_fee,
                created = orderLine.created,
                payment_reference = orderLine.payment_reference,
                note = orderLine.note,
                status = orderLine.status,
                sub_total = orderLine.sub_total,
                total = orderLine.total,
                total_tax = orderLine.total_tax,
                user_id = orderLine.user_id,
                user = orderLine.user.ToDomainModel(),
                orderLines = orderLine?.orderLines?.ToDomainModel(),
                is_active = orderLine.is_active,
                updated = orderLine.updated
            });
        }
        public static IEnumerable<Shopex.Domain.Model.Banners> ToDomainModel(this IEnumerable<Banners> banners, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return banners.Select(banner => new Shopex.Domain.Model.Banners()
            {
                banner_id = banner.banner_id,
                title = banner.title,
                alt_desc = banner.alt_desc,
                created = banner.created,
                description = banner.description,
                end_time = banner.end_time,
                image_url = $"{imageUrl}/banner/{banner.banner_id}.jpg",
                is_active = banner.is_active,
                link_to = banner.link_to,
                placement = banner.placement,
                slug = banner.slug,
                start_time = banner.start_time,
                type = banner.type,

                updated = banner.updated
            });
        }
        public static Shopex.Domain.Model.Categories ToDomainModel(this Categories category, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return new Shopex.Domain.Model.Categories()
            {
                category_id = category.category_id,
                name = category.name,
                parent_id = category.parent_id,
                created = category.created,
                description = category.description,
                image_url = $"{imageUrl}/categoryimages/{category.external_id}.jpg",
                is_active = category.is_active,
                slug = category.slug ,
                external_id = category.external_id,
                order = category.order,
                updated = category.updated,
                external_parent_id = category.external_parent_id
            };
        }
        public static Shopex.Domain.Model.Categories ToDomainModel(this Categories category, IEnumerable<Categories> categories, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return new Shopex.Domain.Model.Categories()
            {
                category_id = category.category_id,
                name = category.name,
                parent_id = category.parent_id,
                created = category.created,
                description = category.description,
                image_url = $"{imageUrl}/categoryimages/{category.external_id}.jpg",
                is_active = category.is_active,
                slug = category.slug,
                updated = category.updated,
                external_id = category.external_id,
                order = category.order,
                subCategories = GetSubCategories(categories, category)

            };
        }
        public static IEnumerable<Shopex.Domain.Model.Categories> ToDomainModel(IEnumerable<Categories> categories, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return categories.Select(category => 
            new Shopex.Domain.Model.Categories()
            {
                category_id = category.category_id,
                name = category.name,
                parent_id = category.parent_id,
                created = category.created,
                description = category.description,
                image_url = $"{imageUrl}/categoryimages/{category.external_id}.jpg",
                is_active = category.is_active,
                slug = category.slug,
                updated = category.updated,
                external_id = category.external_id,
                order = category.order,

            });
        }
        public static Shopex.Domain.Model.Users ToDomainModel(this Users user, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return new Shopex.Domain.Model.Users()
            {
                created = user.created,
                email = user.email,
                first_name = user.first_name,
                last_name = user.last_name,
                is_active = user.is_active,
                last_login = user.last_login,
                password = user.password,
                phone = user.phone,
                updated = user.updated,
                user_id = user.user_id,
                user_name = user.user_name

            };
        }
        public static Shopex.Domain.Model.Carts ToDomainModel(this Carts carts)
        {
            return new Shopex.Domain.Model.Carts()
            {
                cart_id = carts.cart_id,
                created = carts.created,
                is_active = carts.is_active,
                address_id = carts.address_id!=null?(int)(carts.address_id):0,
                price = carts.price,
                product_id = carts.product_id,
                product_price_id = carts.product_price_id,
                updated = carts.updated,
                qty = carts.qty,
                user_id = carts.user_id,
                count = carts.count

            };
        }
        public static IEnumerable<Shopex.Domain.Model.Carts> ToDomainModel(this IEnumerable<Carts> carts, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return carts.Select(cart => new Shopex.Domain.Model.Carts()
            {
                cart_id = cart.cart_id,
                created = cart.created,
                address_id = cart.address_id != null ? (int)(cart.address_id) : 0,
                is_active = cart.is_active,
                price = cart.price,
                product_id = cart.product_id,
                product_price_id = cart.product_price_id,
                qty = cart.qty,
                product = cart.product.ToDomainModel(),
                user_id = cart.user_id,
                updated = cart.updated,
                count = cart.count

            });
        }
        public static Shopex.Domain.Model.Sessions ToDomainModel(Sessions session, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return new Shopex.Domain.Model.Sessions()
            {
               session_id = session.session_id,
               browser =  session.browser,
               created = session.created,
               ip = session.ip,
               is_active = session.is_active

            };
        }
        public static IEnumerable<Shopex.Domain.Model.DeliveryFees> ToDomainModel(this IEnumerable<DeliveryFees> fees,string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return fees.Select(cart => new Shopex.Domain.Model.DeliveryFees()
            {
                fee_id = cart.fee_id,
                max = cart.max,
                min = cart.min,
                name = cart.name,
                price = cart.price,
                created = cart.created,
                is_active = cart.is_active,
                updated = cart.updated

            }) ;
        }
        private static IEnumerable<SubCategories> GetSubCategories(IEnumerable<Categories> categories, Categories pareCategory, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return categories.Where(cat => cat.parent_id == pareCategory.category_id)
                .OrderBy(cat => cat.order)
                .Select(category => new Shopex.Domain.Model.SubCategories()
            {
                category_id = category.category_id,
                name = category.name,
                parent_id = category.parent_id,
                created = category.created,
                description = category.description,
                image_url = $"{imageUrl}/categoryimages/{category.external_id}.jpg",
                    is_active = category.is_active,
                slug = category.slug,
                updated = category.updated,
                external_id = category.external_id,
                order = category.order,
                subCategories = GetSubCategories(categories, category)
            });
            
        }
        public static IEnumerable<Shopex.Domain.Model.Products> ToDomainModel(this IEnumerable<Products> products, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return products.Select(product => new Shopex.Domain.Model.Products()
            {
                product_id = product.product_id,
                brand = product.brand,
                category_id = product.category_id,
                created = product.created,
                description = product.description,
                external_id = product.external_id,
                external_category_id = product.Category.slug,
                image_url= $"{imageUrl}/products/{product.external_id}.jpg",
                is_active = product.is_active,
                name = product.name,
                price = product.price,
                tech_description =  product.tech_description,
                unit = product.unit,
                upc = product.upc,
                updated = product.updated,
                uses = product.uses,
                Category = product.Category.ToDomainModel()
            });
        }
        public static Shopex.Domain.Model.Products ToDomainModel(this Products product, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return new Shopex.Domain.Model.Products()
            {
                product_id = product.product_id,
                brand = product.brand,
                category_id = product.category_id,
                created = product.created,
                description = product.description,
                external_id = product.external_id,
                image_url = $"{imageUrl}/products/{product.external_id}.jpg",
                is_active = product.is_active,
                name = product.name,
                price = product.price,
                tech_description = product.tech_description,
                unit = product.unit,
                upc = product.upc,
                updated = product.updated,
                uses = product.uses,
                produc_prices = product.product_prices.Where(i=>i.is_active == true).ToDomainModel(),
                product_Sizes = product.product_prices.Where(i => i.is_active == true).ToDomainModelGroup(),
                Category = product.Category.ToDomainModel()

            };
        }

        public static IEnumerable<Shopex.Domain.Model.ProductPrices> ToDomainModel(this IEnumerable<ProductPrices> prices, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            return prices.Select(price => new Shopex.Domain.Model.ProductPrices()
            {
                product_id = price.product_id,
                pack_range = price.pack_range,
                is_active = price.is_active,
                price = price.price,
                created = price.created,
                external_product_id = price.external_product_id,
                size1 = price.size1,
                size2 = price.size2,
                updated = price.updated,
                product_price_id = price.product_price_id
            });
        }
        public static IEnumerable<Shopex.Domain.Model.ProductSize> ToDomainModelGroup(this IEnumerable<ProductPrices> prices, string imageUrl = "https://dm62ybhjn914v.cloudfront.net/media/media")
        {
            var sizes = prices.GroupBy(g => g.size1);
            List <Shopex.Domain.Model.ProductSize> productSizes = new List<Shopex.Domain.Model.ProductSize>();   
            foreach (var size in sizes)
            {
                var temp = new ProductSize()
                {
                    size1 = size.Key,

                };
                temp.Packs = new List<ProductPricesDto>();
                foreach (var pack in size)
                {
                    var packTemp = new ProductPricesDto();
                    temp.size2 = pack.size2;
                    packTemp.size2 = pack.size2;
                    packTemp.size1 = pack.size2;
                    packTemp.pack_range = pack.pack_range?.Split('~')?.Select(i => Convert.ToInt32(i));
                    packTemp.price = pack.price;
                    packTemp.product_price_id = pack.product_price_id;
                    packTemp.external_product_id = pack.external_product_id;
                    temp.Packs.Add(packTemp);
                   
                }
                productSizes.Add(temp);
            }
            return productSizes;

        }
        public static Shopex.Domain.Model.ProductPrices ToDomainModel(this ProductPrices price, string imageUrl = "http:/51.75.68.69:3001")
        {
            return new Shopex.Domain.Model.ProductPrices()
            {
                product_id = price.product_id,
                pack_range = price.pack_range,
                is_active = price.is_active,
                price = price.price,
                created = price.created,
                external_product_id = price.external_product_id,
                size1 = price.size1,
                size2 = price.size2,
                updated = price.updated,
                product_price_id = price.product_price_id
            };
        }

    }
}
