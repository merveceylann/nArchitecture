using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetListBrand
{
    public class GetListBrandQuery : IRequest<BrandListModel>
    //domain nesnelerini api ile tasimiyoruz frontende!
    //dto yapmadik cunku daha fazla bilgi icerecek (dto: vtden gelen datanin gorunumu) 
    //neden model cunku sadece brand listesi degil icinde farkli bilgiler de icerecek ornegin joinle vs (mvc de model gibi o da encapsulationdan geliyor)
    {

        public PageRequest PageRequest { get; set; }

        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
        {

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                BrandListModel mapperBrandListModel = _mapper.Map<BrandListModel>(brands);
                return mapperBrandListModel;
            }
        }
    }
}
