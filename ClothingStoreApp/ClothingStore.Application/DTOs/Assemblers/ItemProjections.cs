using ClothingStore.Domain.Entities;
using System.Linq.Expressions;

namespace ClothingStore.Application.DTOs.Assemblers
{
    public static class ItemProjections
    {
        public static readonly Expression<Func<Item, ItemDto>> ItemToDto =
            item => new ItemDto
            {
                ItemId = item.ItemId,
                Name = item.Name,
                Description = item.Description,
                Hot = item.Hot,
                Price = item.Price,
                Discount = item.Discount,
                LastChance = item.LastChance,
                Brand = item.Brand,
                Collection = item.Collection,
                CareGuide = item.CareGuide,
                MaterialDistribution = item.MaterialDistribution,
                CreatedAt = item.CreatedAt,
                Variants = item.Variants.Select(v => new VariantDto
                {
                    VariantId = v.VariantId,
                    ItemId = v.ItemId,
                    Color = new ColorDto
                    {
                        Hexadecimal = v.Color.Hexadecimal,
                        Red = v.Color.Red,
                        Green = v.Color.Green,
                        Blue = v.Color.Blue
                    },
                    AvailableLocations = v.AvailableLocations.Select(al => new AvailableLocationBySizeDto
                    {
                        AvailableLocationBySizeId = al.AvailableLocationBySizeId,
                        VariantId = al.VariantId,
                        SizeId = al.SizeId,
                        AvailableLocationsOfGivenSize = al.AvailableLocationsOfGivenSize.Select(s => new StockByLocationDto
                        {
                            StockByLocationId = s.StockByLocationId,
                            AvailableLocationBySizeId = s.LocationBySizeId,
                            Stock = s.Stock,
                            Location = new LocationDto
                            {
                                Latitude = s.Location.Latitude,
                                Longitude = s.Location.Longitude,
                                Address = s.Location.Address
                            }
                        }).ToList()
                    }).ToList(),
                    Gallery = v.Gallery.Select(g => new PhotoDto
                    {
                        PhotoId = g.PhotoId,
                        VariantId = g.VariantId,
                        Url = g.Url,
                        Description = g.Description,
                        UploadedAt = g.UploadedAt
                    }).ToList()
                }).ToList(),
                Tags = item.Tags.Select(t => new TagDto
                {
                    TagId = t.TagId,
                    Name = t.Name,
                    Ordinal = t.Ordinal
                }).ToList()
            };
    }
    
}
