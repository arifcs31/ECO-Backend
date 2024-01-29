using Shopex.Infrastructure.DB.Model;

namespace Shopex.Infrastructure.Mappings
{
    public static class DomainModelToDBModelMappings
    {
        public static Banners ToDBModel(this Shopex.Domain.Model.Banners banner)
        {
            return new Banners()
            {
                banner_id = banner.banner_id,
                title = banner.title,
                alt_desc = banner.alt_desc,
                created = banner.created,
                description = banner.description,
                end_time = banner.end_time,
                image_url = banner.image_url,
                is_active = banner.is_active,
                link_to = banner.link_to,
                placement = banner.placement,
                slug = banner.slug,
                start_time = banner.start_time,
                type = banner.type,
                updated = banner.updated
            };
        }
        public static Users ToDBModel(this Shopex.Domain.Model.Users user, string imageUrl = "http://51.75.68.69:3001")
        {
            return new Users()
            {
                created = user.created,
                email = user.email,
                first_name = user.first_name,
                last_name = user.last_name,
                is_active = (bool)user.is_active,
                last_login = user.last_login,
                password = user.password,
                phone = user.phone,
                updated = user.updated,
                user_id = user.user_id,
                user_name = user.email

            };
        }
        public static Sessions ToDBModel(this Shopex.Domain.Model.Sessions session, string imageUrl = "http://51.75.68.69:3001")
        {
            return new Sessions()
            {
                session_id = session.session_id,
                browser = session.browser,
                created = session.created,
                ip = session.ip,
                is_active = session.is_active

            };
        }
        public static Address ToDBModel(this Shopex.Domain.Model.Address banner, string imageUrl = "http://51.75.68.69:3001")
        {
            return new Address()
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
                address = banner.address,
                user_id = banner.user_id,
                is_active = banner.is_active,
                updated = banner.updated,
                type = banner.type
            };
        }
        public static Carts ToDBModel(this Shopex.Domain.Model.Carts carts)
        {
            return new Carts()
            {
                cart_id = carts.cart_id,
                created = carts.created,
                is_active = carts.is_active,
                qty = carts.qty,
                user_id = carts.user_id == 0 ? null : carts.user_id,
                session_id = carts.session_id,
                price = carts.price,
                product_id = carts.product_id,
                product_price_id = carts.product_price_id,
                updated = carts.updated,
                count = carts.count
                
            };
        }
        public static IEnumerable<Carts> ToDBModel(this IEnumerable<DB.Model.Carts> carts)
        {
            return carts.Select(cart => new Carts()
            {
                cart_id = cart.cart_id,
                created = cart.created,
                is_active = cart.is_active,
                price = cart.price,
                qty = cart.qty,
                user_id = cart.user_id,
                product_id = cart.product_id,
                product_price_id = cart.product_price_id,
                updated = cart.updated,
                count  = cart.count

            });
        }
        public static Order_Lines ToDbModel(this Shopex.Domain.Model.OrderLines orderLine, string imageUrl = "http://51.75.68.69:3001")
        {
            return new Order_Lines()
            {
                order_id = orderLine.order_id,
                order_line_id = orderLine.order_line_id,
                price = orderLine.price,
                product_id = orderLine.product_id,
                created = orderLine.created,
                product_price_id = orderLine.product_price_id,
                qty = orderLine.qty,
                product = orderLine?.product?.ToDBModel(),
                productPrice = orderLine?.productPrice?.ToDBModel(),
                is_active = orderLine.is_active,
                updated = orderLine.updated,
                count= orderLine?.count
            };
        }
        public static IEnumerable<Order_Lines> ToDBModel(this IEnumerable<Shopex.Domain.Model.OrderLines> address, string imageUrl = "http://51.75.68.69:3001")
        {
            return address.Select(orderLine => new Order_Lines()
            {
                order_id = orderLine.order_id,
                order_line_id = orderLine.order_line_id,
                price = orderLine.price,
                product_id = orderLine.product_id,
                created = orderLine.created,
                product_price_id = orderLine.product_price_id,
                qty = orderLine.qty,
                product = orderLine?.product?.ToDBModel(),
                productPrice = orderLine?.productPrice?.ToDBModel(),
                is_active = orderLine.is_active,
                updated = orderLine.updated,
                count = orderLine.count
            });
        }
        public static Orders ToDbModel(this Shopex.Domain.Model.Orders orderLine, string imageUrl = "http://51.75.68.69:3001")
        {
            return new Orders()
            {
                address_id = orderLine.address_id,
                delivery_fee = orderLine.delivery_fee,
                created = DateTime.UtcNow,
                payment_reference = orderLine.payment_reference,
                note = orderLine.note,
                status = orderLine.status,
                sub_total = orderLine.sub_total,
                total = orderLine.total,
                total_tax = orderLine.total_tax,
                user_id = orderLine.user_id,
                orderLines = orderLine.orderLines.ToDBModel().ToList(),
                is_active = orderLine.is_active,
                updated = orderLine.updated

            };
        }
        public static OrderLogs ToDbModel(this Shopex.Domain.Model.OrderLogs orderLog, string imageUrl = "http://51.75.68.69:3001")
        {
            return new OrderLogs()
            {
                order_log_id = orderLog.order_log_id,
                error = orderLog.error,
                external_id = orderLog.external_id,
                extra_info = orderLog.extra_info,
                request = orderLog.request,
                created = DateTime.UtcNow,
                updated = orderLog.updated,
                user_id = orderLog.user_id
            };
        }
        public static IEnumerable<Orders> ToDBModel(this IEnumerable<Shopex.Domain.Model.Orders> address, string imageUrl = "http://51.75.68.69:3001")
        {
            return address.Select(orderLine => new Orders()
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
                orderLines = (ICollection<Order_Lines>)orderLine.orderLines.ToDBModel(),
                is_active = orderLine.is_active,
                updated = orderLine.updated
            });
        }
        public static Categories ToDBModel(this Shopex.Domain.Model.Categories category)
        {
            return new Categories()
            {
                category_id = category.category_id,
                name = category.name,
                parent_id = category.parent_id,
                created = category.created,
                description = category.description,
                image_url = category.image_url,
                is_active = category.is_active,
                slug = category.slug,
                updated = category.updated,
                external_id = category.external_id,
                order = category.order,
                external_parent_id = category.external_parent_id,
            };
        }
        public static IEnumerable<Shopex.Infrastructure.DB.Model.Products> ToDBModel(this IEnumerable<Shopex.Domain.Model.Products> products)
        {
            return products.Select(product => new Shopex.Infrastructure.DB.Model.Products()
            {
                product_id = product.product_id,
                brand = product.brand,
                category_id = product.category_id,
                created = product.created,
                description = product.description,
                external_id = product.external_id,
                image_url = product.image_url,
                is_active = product.is_active,
                name = product.name,
                price = product.price,
                tech_description = product.tech_description,
                unit = product.unit,
                upc = product.upc,
                updated = product.updated,
                uses = product.uses,
                show_on_landing = product.show_on_landing,
                link_upc = product.link_upc,
            });
        }
        public static Shopex.Infrastructure.DB.Model.Products ToDBModel(this Shopex.Domain.Model.Products product)
        {
            return new Shopex.Infrastructure.DB.Model.Products()
            {
                product_id = product.product_id,
                brand = product.brand,
                category_id = product.category_id,
                created = product.created,
                description = product.description,
                external_id = product.external_id,
                image_url = product.image_url,
                is_active = product.is_active,
                name = product.name,
                price = product.price,
                tech_description = product.tech_description,
                unit = product.unit,
                upc = product.upc,
                updated = product.updated,
                uses = product.uses,
                show_on_landing = product.show_on_landing,
                link_upc = product.link_upc,
                
            };
        }

        public static IEnumerable<Product_Prices> ToDBModel(this IEnumerable<Shopex.Domain.Model.ProductPrices> prices)
        {
            return prices.Select(price => new Product_Prices()
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
        public static Product_Prices ToDBModel(this Shopex.Domain.Model.ProductPrices price)
        {
            return new Product_Prices()
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
