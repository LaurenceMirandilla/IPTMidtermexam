using AutoMapper;
using IPTMidtermexam.DTO;
using IPTMidtermexam.DTO.CustomerDTO;
using IPTMidtermexam.DTO.ProductDTO;
using IPTMidtermexam.DTO.TransactionDTO;
using IPTMidtermexam.Model;
using IPTMidtermexam.Model.Domain;

namespace IPTMidtermexam.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<UpdateCustomerDTO, Customer>();
            CreateMap<DeleteCustomerDTO, Customer>();

            CreateMap<Product, ProductDTO>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<DeleteProductDTO, Product>();


            CreateMap<Transaction, TransactionDTO>()
        .ForMember(dest => dest.TransactionItems, opt => opt.MapFrom(src => src.TransactionItems));

            CreateMap<CreateTransactionDTO, Transaction>()
              .ForMember(dest => dest.TransactionItems, opt => opt.MapFrom(src => src.TransactionItems));


            CreateMap<UpdateTransactionDTO, Transaction>()
                .ForMember(dest => dest.TransactionItems, opt => opt.MapFrom(src => src.TransactionItems));

            CreateMap<DeleteTransactionDTO, Transaction>();
            CreateMap<TransactionItem, TransactionItemDTO>(); 


        }
    }
}