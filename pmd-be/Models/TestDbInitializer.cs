namespace pmd_be.Models;
internal class TestDbInitializer
{
    internal static void Initialize(PmdDbContext dbContext, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        dbContext.Database.EnsureCreated();
        if (dbContext.Products.Any())
            return;
        logger.LogInformation("Seeding db with mock products");
        var products = new Product[]
        {
                new Product{ Id = Guid.NewGuid(), Name = "Product 01", Code = "NA74-7443H", Price = 22.85M, SKU = "837462-A1", StockQuantity = 89, DateAdded =  DateTimeOffset.Parse("2023-09-19T13:20:02.289Z"), Category = 1},
                new Product{ Id = Guid.NewGuid(), Name = "Product 02", Code = "KGT8-UH66W", Price = 22.85M, SKU = "493857-B5", StockQuantity = 132, DateAdded =  DateTimeOffset.Parse("2022-09-19T13:20:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 03", Code = "DELT-8A223", Price = 22.85M, SKU = "209374-C9", StockQuantity = 194, DateAdded =  DateTimeOffset.Parse("2021-09-19T13:20:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 04", Code = "90TE-XZ34T", Price = 22.85M, SKU = "745839-D3", StockQuantity = 10, DateAdded =  DateTimeOffset.Parse("2024-09-19T13:20:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 05", Code = "GOA7-RR93T", Price = 22.85M, SKU = "659472-E7", StockQuantity = 99, DateAdded =  DateTimeOffset.Parse("2024-03-19T13:20:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 06", Code = "J8HY-TR56L", Price = 35.95M, SKU = "837462-A1", StockQuantity = 54, DateAdded = DateTimeOffset.Parse("2024-09-01T12:20:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 07", Code = "M9NW-YT78P", Price = 28.50M, SKU = "493857-B5", StockQuantity = 99, DateAdded = DateTimeOffset.Parse("2023-08-19T13:20:02.289Z"), Category = 1},
                new Product{ Id = Guid.NewGuid(), Name = "Product 08", Code = "R3KX-PL94N", Price = 42.30M, SKU = "209374-C9", StockQuantity = 75, DateAdded = DateTimeOffset.Parse("2022-07-22T15:30:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 09", Code = "T4VZ-XQ23H", Price = 27.80M, SKU = "745839-D3", StockQuantity = 104, DateAdded = DateTimeOffset.Parse("2024-06-19T16:45:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 10", Code = "W6LC-MK89R", Price = 19.99M, SKU = "748392-E7", StockQuantity = 62, DateAdded = DateTimeOffset.Parse("2021-05-14T09:55:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 11", Code = "P8QJ-NU66L", Price = 32.45M, SKU = "394857-F2", StockQuantity = 87, DateAdded = DateTimeOffset.Parse("2023-04-18T14:20:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 12", Code = "Z9OP-HG34K", Price = 24.99M, SKU = "203948-G9", StockQuantity = 111, DateAdded = DateTimeOffset.Parse("2024-03-21T11:35:02.289Z"), Category = 1},
                new Product{ Id = Guid.NewGuid(), Name = "Product 13", Code = "C7XN-QJ89T", Price = 40.25M, SKU = "847362-H1", StockQuantity = 53, DateAdded = DateTimeOffset.Parse("2022-02-10T07:45:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 14", Code = "L4YM-KV22X", Price = 21.75M, SKU = "583742-I6", StockQuantity = 94, DateAdded = DateTimeOffset.Parse("2021-01-05T06:55:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 15", Code = "U3RK-BH77P", Price = 29.99M, SKU = "948572-J8", StockQuantity = 76, DateAdded = DateTimeOffset.Parse("2023-12-15T17:15:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 16", Code = "V2NH-TY56M", Price = 38.50M, SKU = "203857-K9", StockQuantity = 61, DateAdded = DateTimeOffset.Parse("2024-11-19T08:25:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 17", Code = "F8YR-PQ11L", Price = 26.75M, SKU = "678934-L3", StockQuantity = 117, DateAdded = DateTimeOffset.Parse("2022-10-24T19:35:02.289Z"), Category = 1},
                new Product{ Id = Guid.NewGuid(), Name = "Product 18", Code = "K5ZT-RY44N", Price = 45.95M, SKU = "384720-M7", StockQuantity = 95, DateAdded = DateTimeOffset.Parse("2021-09-13T12:45:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 19", Code = "X1VU-LJ98Q", Price = 22.85M, SKU = "947263-N2", StockQuantity = 88, DateAdded = DateTimeOffset.Parse("2024-08-19T10:55:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 20", Code = "T3YR-QW67B", Price = 36.30M, SKU = "295847-O5", StockQuantity = 67, DateAdded = DateTimeOffset.Parse("2023-07-19T14:20:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 21", Code = "R7NX-VK21Z", Price = 33.49M, SKU = "578392-P4", StockQuantity = 102, DateAdded = DateTimeOffset.Parse("2022-06-29T16:30:02.289Z"), Category = 1},
                new Product{ Id = Guid.NewGuid(), Name = "Product 22", Code = "H5WR-BN43L", Price = 28.99M, SKU = "839204-Q8", StockQuantity = 59, DateAdded = DateTimeOffset.Parse("2021-05-18T07:40:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 23", Code = "N9XT-JK67R", Price = 31.75M, SKU = "594837-R2", StockQuantity = 134, DateAdded = DateTimeOffset.Parse("2024-04-19T09:15:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 24", Code = "P6XC-TQ34H", Price = 39.99M, SKU = "748392-S9", StockQuantity = 70, DateAdded = DateTimeOffset.Parse("2023-03-19T17:25:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 25", Code = "W1RK-HJ98N", Price = 23.45M, SKU = "203948-T1", StockQuantity = 83, DateAdded = DateTimeOffset.Parse("2022-02-19T11:35:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 26", Code = "M8NY-PL56X", Price = 20.25M, SKU = "657392-U4", StockQuantity = 115, DateAdded = DateTimeOffset.Parse("2021-01-14T06:55:02.289Z"), Category = 1},
                new Product{ Id = Guid.NewGuid(), Name = "Product 27", Code = "F3VP-KJ77M", Price = 29.85M, SKU = "847365-V6", StockQuantity = 97, DateAdded = DateTimeOffset.Parse("2024-12-19T17:05:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 28", Code = "L7WU-BX34Q", Price = 44.99M, SKU = "394857-W9", StockQuantity = 66, DateAdded = DateTimeOffset.Parse("2023-11-19T07:15:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 29", Code = "Q5YR-NT98L", Price = 30.50M, SKU = "748392-X2", StockQuantity = 110, DateAdded = DateTimeOffset.Parse("2022-10-19T12:25:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 30", Code = "K8XT-VL22P", Price = 25.95M, SKU = "203948-Y7", StockQuantity = 74, DateAdded = DateTimeOffset.Parse("2021-09-19T15:35:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 31", Code = "T9LK-MX77C", Price = 37.85M, SKU = "937482-A4", StockQuantity = 128, DateAdded = DateTimeOffset.Parse("2024-08-11T09:40:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 32", Code = "R6YX-JK12V", Price = 21.99M, SKU = "573920-B8", StockQuantity = 92, DateAdded = DateTimeOffset.Parse("2023-05-15T10:25:02.289Z"), Category = 1},
                new Product{ Id = Guid.NewGuid(), Name = "Product 33", Code = "H2WQ-PR98L", Price = 34.75M, SKU = "293847-C5", StockQuantity = 84, DateAdded = DateTimeOffset.Parse("2022-12-19T14:55:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 34", Code = "Q4LX-NY45T", Price = 25.60M, SKU = "184937-D3", StockQuantity = 106, DateAdded = DateTimeOffset.Parse("2021-11-13T12:15:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 35", Code = "M7TW-ZP23J", Price = 29.99M, SKU = "847592-E7", StockQuantity = 78, DateAdded = DateTimeOffset.Parse("2024-10-19T16:05:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 36", Code = "Y5RN-XC45M", Price = 18.45M, SKU = "349857-F9", StockQuantity = 95, DateAdded = DateTimeOffset.Parse("2023-07-14T11:25:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 37", Code = "V8QJ-MT89N", Price = 27.25M, SKU = "758392-G6", StockQuantity = 101, DateAdded = DateTimeOffset.Parse("2022-09-22T15:55:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 38", Code = "L3WP-HK12X", Price = 40.95M, SKU = "495837-H3", StockQuantity = 89, DateAdded = DateTimeOffset.Parse("2021-08-11T13:15:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 39", Code = "T1RQ-ZJ34L", Price = 33.60M, SKU = "748392-I2", StockQuantity = 70, DateAdded = DateTimeOffset.Parse("2024-06-10T08:30:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 40", Code = "P9TY-LN98P", Price = 22.75M, SKU = "204857-J7", StockQuantity = 111, DateAdded = DateTimeOffset.Parse("2023-04-29T17:35:02.289Z"), Category = 1},
                new Product{ Id = Guid.NewGuid(), Name = "Product 41", Code = "K2XY-WJ11C", Price = 38.20M, SKU = "948372-K5", StockQuantity = 67, DateAdded = DateTimeOffset.Parse("2022-02-25T14:45:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 42", Code = "M5WQ-TH56X", Price = 19.99M, SKU = "573829-L3", StockQuantity = 54, DateAdded = DateTimeOffset.Parse("2021-10-14T06:55:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 43", Code = "Q7RK-MN34V", Price = 42.85M, SKU = "184937-M2", StockQuantity = 97, DateAdded = DateTimeOffset.Parse("2024-12-19T12:35:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 44", Code = "N9XJ-RQ89B", Price = 30.50M, SKU = "748293-N7", StockQuantity = 74, DateAdded = DateTimeOffset.Parse("2023-11-12T09:25:02.289Z"), Category = 1},
                new Product{ Id = Guid.NewGuid(), Name = "Product 45", Code = "V4WP-HK12M", Price = 26.75M, SKU = "594837-O9", StockQuantity = 121, DateAdded = DateTimeOffset.Parse("2022-08-22T19:15:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 46", Code = "K7TR-JX45L", Price = 35.99M, SKU = "748392-P1", StockQuantity = 86, DateAdded = DateTimeOffset.Parse("2021-06-15T14:35:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 47", Code = "M3QT-LN67X", Price = 23.45M, SKU = "384720-Q8", StockQuantity = 59, DateAdded = DateTimeOffset.Parse("2024-05-19T11:45:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 48", Code = "T1XY-WC12H", Price = 29.95M, SKU = "495837-R2", StockQuantity = 100, DateAdded = DateTimeOffset.Parse("2023-09-19T13:55:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 49", Code = "P9NK-BJ77V", Price = 41.20M, SKU = "593847-S4", StockQuantity = 85, DateAdded = DateTimeOffset.Parse("2022-07-17T16:05:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 50", Code = "K4XN-MT12Q", Price = 32.99M, SKU = "837462-T6", StockQuantity = 76, DateAdded = DateTimeOffset.Parse("2021-05-18T12:55:02.289Z"), Category = 1},
                new Product{ Id = Guid.NewGuid(), Name = "Product 51", Code = "M8WR-QC34L", Price = 24.75M, SKU = "947263-U3", StockQuantity = 66, DateAdded = DateTimeOffset.Parse("2024-04-19T18:20:02.289Z"), Category = 3},
                new Product{ Id = Guid.NewGuid(), Name = "Product 52", Code = "Q3WJ-LX89H", Price = 38.30M, SKU = "284957-V7", StockQuantity = 109, DateAdded = DateTimeOffset.Parse("2023-03-14T11:30:02.289Z"), Category = 2},
                new Product{ Id = Guid.NewGuid(), Name = "Product 53", Code = "R9TZ-PJ12X", Price = 26.99M, SKU = "394857-W8", StockQuantity = 57, DateAdded = DateTimeOffset.Parse("2022-01-22T14:45:02.289Z"), Category = 5},
                new Product{ Id = Guid.NewGuid(), Name = "Product 54", Code = "L2XQ-WK67V", Price = 31.50M, SKU = "748392-X1", StockQuantity = 91, DateAdded = DateTimeOffset.Parse("2021-12-18T09:55:02.289Z"), Category = 4},
                new Product{ Id = Guid.NewGuid(), Name = "Product 55", Code = "K5QJ-MC45L", Price = 28.85M, SKU = "394857-Y3", StockQuantity = 113, DateAdded = DateTimeOffset.Parse("2024-10-19T07:15:02.289Z"), Category = 2},


        };

        dbContext.Products.AddRange(products);

        dbContext.SaveChanges();
    }
}
