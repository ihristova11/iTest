using AutoMapper;
using iTest.Data.Models;
using iTest.DTO;
using iTest.Web.Areas.Admin.Models;

namespace iTest.Web
{
    public class MappingSettings : Profile
    {

        public MappingSettings()
        {
            this.ViewModelsAndDtosMappings();
            this.DtosAndDataModelsMappings();
        }

        private void ViewModelsAndDtosMappings()
        {
            //Test:
            //From ViewModel to Dto
            this.CreateMap<TestViewModel, TestDTO>(MemberList.Source)
                .ForMember(t => t.Questions, o => o.MapFrom(t => t.Questions))
                .ForPath(t => t.Category.Name, o => o.MapFrom(t => t.Category))
                .ReverseMap();

            this.CreateMap<CreateQuestionViewModel, QuestionDTO>()
                .ForMember(q => q.Description, o => o.MapFrom((q => q.Description)))
                .ForMember(q => q.Answers, o => o.MapFrom(q => q.Answers));

            this.CreateMap<CreateAnswerViewModel, AnswerDTO>()
                .ForMember(a => a.Description, o => o.MapFrom(a => a.Description));

        }

        private void DtosAndDataModelsMappings()
        {
            //Test:
            //From ViewModel to Dto
            this.CreateMap<Category, CategoryDTO>(MemberList.Source)
                .ForMember(c => c.Name, o => o.MapFrom(t => t.Name))
                .ReverseMap();

            this.CreateMap<Test, TestDTO>(MemberList.Source)
                .ForMember(t => t.Questions, o => o.MapFrom(t => t.Questions))
                .ForPath(t => t.Category.Name, o => o.MapFrom(t => t.Category.Name))
                .ReverseMap();

            this.CreateMap<QuestionDTO, Question>(MemberList.Source)
                .ForMember(q => q.Description, o => o.MapFrom((q => q.Description)))
                .ForMember(q => q.Answers, o => o.MapFrom(q => q.Answers));
            


            //this.CreateMap<TestDTO, Test>(MemberList.Source);
            //this.CreateMap<CategoryDTO, Category>(MemberList.Source);
            //this.CreateMap<QuestionDTO, Question>(MemberList.Source);
            this.CreateMap<AnswerDTO, Answer>(MemberList.Source);
            this.CreateMap<ResultDTO, Result>(MemberList.Source);
        }


        //private void DtosAndDataModelsMappings()
        //{
        //    //From Dto to DataModel
        //    this.CreateMap<ManageTestDto, Test>()
        //        .ForMember(t => t.Name, o => o.MapFrom(t => t.TestName))
        //        .ForMember(t => t.Duration, o => o.MapFrom(t => t.RequestedTime))
        //        .ForMember(t => t.Questions, o => o.MapFrom(t => t.Questions))
        //        .ReverseMap()
        //        .ForMember(t => t.CategoryName, o => o.MapFrom(t => t.Category.Name));

        //    this.CreateMap<ManageQuestionDto, Question>()
        //        .ForMember(q => q.Answers, o => o.MapFrom(q => q.Answers))
        //        .ReverseMap();

        //    this.CreateMap<ManageAnswerDto, Answer>()
        //        .ReverseMap();


        //    //From Test to Dto
        //    this.CreateMap<Test, TestDashBoardDto>()
        //        .ForMember(t => t.CategoryName, o => o.MapFrom(t => t.Category.Name))
        //        .ForMember(t => t.TestName, o => o.MapFrom(t => t.Name));


        //    // Without .MaxDepth() - stackoverflow exception in GetTestById() in Test
        //    // Service - Ask why
        //    this.CreateMap<Test, TestDto>(MemberList.Source)
        //      .ForMember(q => q.Questions, o => o.MapFrom(x => x.Questions))
        //      .MaxDepth(3)
        //      .ReverseMap();

        //    this.CreateMap<Question, QuestionDto>()
        //        .ForMember(q => q.Answers, o => o.MapFrom(x => x.Answers));

        //    this.CreateMap<Answer, AnswerDto>();


        //    this.CreateMap<CategoryDto, Category>(MemberList.Source)
        //        .ReverseMap().MaxDepth(3);


        //    this.CreateMap<UserTest, UserTestResultDto>(MemberList.Destination)
        //        .ForMember(ut => ut.TestName, o => o.MapFrom(ut => ut.Test.Name))
        //        .ForMember(ut => ut.UserName, o => o.MapFrom(ut => ut.User.UserName))
        //        .ForMember(ut => ut.CategoryName, o => o.MapFrom(ut => ut.Test.Category.Name))
        //        .ForMember(ut => ut.RequestedTime, o => o.MapFrom(ut => ut.Test.Duration));


        //    this.CreateMap<UserTestDto, UserTest>().ReverseMap();


        //    this.CreateMap<UserAnswer, UserAnswerDto>(MemberList.Source)
        //        .ReverseMap();

        //}
    }
}