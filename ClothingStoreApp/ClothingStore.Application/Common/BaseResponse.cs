using MediatR;

namespace ClothingStore.Application.Common
{
    public class BaseResponse<T>: IRequest<T> where T : class
    {
        public bool OK { get; set; } = true;
        public IReadOnlyList<string> Errors { get; set; } = new List<string>();
    }
}
