using System;
using System.Threading.Tasks;
using Refit;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Contracts.V1.Responses;

namespace PicoYPlacaPredictor.Sdk
{
    public interface IPicoYPlacaPredictorApi
    {
        [Get("/api/v1/posts")]
        Task<ApiResponse<PagedResponse<PostResponse>>> GetAllAsync();

        [Get("/api/v1/posts/{postId}")]
        Task<ApiResponse<Response<PostResponse>>> GetAsync(Guid postId);

        [Post("/api/v1/posts")]
        Task<ApiResponse<Response<PostResponse>>> CreateAsync([Body] CreatePostRequest createPostRequest);
    }
}
