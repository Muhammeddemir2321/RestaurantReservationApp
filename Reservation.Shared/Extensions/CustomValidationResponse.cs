﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Shared.DTO_s;

namespace Reservation.Shared.Extensions
{
    public static class CustomValidationResponce
    {
        public static void UseCustomValidationResponce(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(x => x.Errors).Select(x => x.ErrorMessage);

                    ErrorDto errorDto = new ErrorDto(errors.ToList(), true);

                    var responce = ResponseDto<NoContent>.Fail(errorDto, 400);

                    return new BadRequestObjectResult(responce);
                };
            });
        }
    }
}
