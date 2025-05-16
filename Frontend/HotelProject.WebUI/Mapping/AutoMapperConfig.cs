using AutoMapper;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.TestimonialDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Contact;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using HotelProject.WebUI.Dtos.WorkLocationDto;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Models.Role;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();
            CreateMap<AppUser, ResultAppUserDto>()
           .ForMember(dest => dest.WorkLocationName, opt => opt.MapFrom(
               src => src.WorkLocation.WorkLocationName));
            CreateMap<ResultAppUserListDto, AppUser>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
            CreateMap<CreateRoomDto, Room>().ReverseMap();

            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();

            CreateMap<ResultStaffDto, Staff>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ResultBookingDto, Booking>().ReverseMap();
            CreateMap<ApproveBookingDto, Booking>().ReverseMap();

            CreateMap<CreateContactDto , Contact>().ReverseMap();
            CreateMap<InboxContactDto , Contact>().ReverseMap();
            CreateMap<SidebarContactViewModel , Contact>().ReverseMap();
            CreateMap<GetContactByIDDto , Contact>().ReverseMap();

            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<ResultGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();

            CreateMap<CreateSendMessageDto, SendMessage>().ReverseMap();
            CreateMap<ResultSendboxDto, SendMessage>().ReverseMap();
            CreateMap<GetMessageByIDDto, SendMessage>().ReverseMap();

            CreateMap<ResultMessageCategoryDto, MessageCategory>().ReverseMap();

            CreateMap<CreateWorkLocationDto, WorkLocation>().ReverseMap();
            CreateMap<ResultWorkLocationDto, WorkLocation>().ReverseMap();
            CreateMap<UpdateWorkLocationDto, WorkLocation>().ReverseMap();

            CreateMap<AddRoleViewModel, AppRole>().ReverseMap();


        }
    }
}
