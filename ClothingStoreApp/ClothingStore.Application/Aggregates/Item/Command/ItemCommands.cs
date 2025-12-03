using ClothingStore.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Application.Aggregates.Item.Command
{
    public class AddItemCommandResponse: BaseResponse
    {
        public string Id { get; set; }
    }

    public class AddItemCommand: IRequest<AddItemCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Hot { get; set; }
        public decimal Price { get; set; }
        public bool LastChance { get; set; }
        public string Collection {  get; set; }
        public string careGuide { get; set; }
        public string MaterialDistribution { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
