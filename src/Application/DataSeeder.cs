using System.Collections.ObjectModel;
using Application.UnitOfWork;
using Domain;

namespace Application;

public class DataSeeder(IUnitOfWork unitOfWork)
{
    public async Task Seed()
    {
        // unitOfWork.StocksRepository.AddRange(GetStocks());
        unitOfWork.IndicesRepository.AddRange(GetIndices());
        await unitOfWork.SaveChangesAsync();
    }

    private IList<Indice> GetIndices()
    {
        var list = new Collection<Indice>
        {
            new()
            {
                Name = "NDX",
                Stocks = GetStocks()
            }
        };

        return list;
    }

    private IList<Stock> GetStocks()
    {
        var list = new Collection<Stock>
        {
            new ()
            {
                Name = "TSLA",
                Quantity = 1862996,
                Price = 371.82m
            },
            new ()
            {
                Name = "AAPL",
                Quantity = 95785,
                Price = 242.80m
            },
            new ()
            {
                Name = "AMZN",
                Quantity = 219066,
                Price = 220.92m
            }
        };
        
        return list;
    }
}