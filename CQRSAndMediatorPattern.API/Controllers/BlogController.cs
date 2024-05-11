using System.Net;
using CQRSAndMediatorPattern.Application.Blogs.Commands.CreateBlog;
using CQRSAndMediatorPattern.Application.Blogs.Commands.DeleteBlog;
using CQRSAndMediatorPattern.Application.Blogs.Commands.UpdateBlog;
using CQRSAndMediatorPattern.Application.Blogs.Models.Requests;
using CQRSAndMediatorPattern.Application.Blogs.Queries.GetAllBlogs;
using CQRSAndMediatorPattern.Application.Blogs.Queries.GetBlogById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatorPattern.API.Controllers;

public class BlogController(IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllBlogs(CancellationToken cancellationToken = default)
    {
        try
        {
            var query = new GetAllBlogsQuery();
            var response = await mediator.Send(query, cancellationToken);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return Problem(detail: response.Message, statusCode: (int)response.StatusCode);
            }

            return Ok(response.Data);
        }
        catch (Exception ex)
        {
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Server Error",
                detail: ex.Message);
        }
    }

    [HttpGet]
    [Route("{blogId:int}")]
    public async Task<IActionResult> GetBlog(int blogId, CancellationToken cancellationToken = default)
    {
        try
        {
            if (blogId <= 0)
            {
                return Problem(detail: "Blog Id is invalid. Please enter valid blog id", statusCode: StatusCodes.Status400BadRequest);
            }

            var query = new GetBlogByIdQuery(blogId);
            var response = await mediator.Send(query, cancellationToken);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return Problem(detail: response.Message, statusCode: (int)response.StatusCode);
            }

            return Ok(response.Data);
        }
        catch (Exception ex)
        {
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Server Error",
                detail: ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] CreateBlogRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var command = new CreateBlogCommand(request);
            var response = await mediator.Send(command, cancellationToken);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return Problem(detail: response.Message, statusCode: (int)response.StatusCode);
            }

            return CreatedAtAction(nameof(GetBlog), new { blogId = response.Data.Id }, response.Data);
        }
        catch (Exception ex)
        {
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Server Error",
                detail: ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdateBlogCommand(request);
            var response = await mediator.Send(command, cancellationToken);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return Problem(detail: response.Message, statusCode: (int)response.StatusCode);
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Server Error",
                detail: ex.Message);
        }
    }

    [HttpDelete]
    [Route("{blogId:int}")]
    public async Task<IActionResult> DeleteBlog(int blogId, CancellationToken cancellationToken = default)
    {
        try
        {
            if (blogId <= 0)
            {
                return Problem(detail: "Blog Id is invalid. Please enter valid blog id", statusCode: StatusCodes.Status400BadRequest);
            }

            var command = new DeleteBlogCommand(blogId);
            var response = await mediator.Send(command, cancellationToken);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return Problem(detail: response.Message, statusCode: (int)response.StatusCode);
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Server Error",
                detail: ex.Message);
        }
    }
}
