using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResultNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efcore_issue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("insert")]
        public async Task<Result> InsertAsync(
            [FromServices] ApplicationDbContext dbContext)
        {
            var entities = new List<Root>(100);

            for (int i = 0; i < 100; i++)
            {
                var model = new Root
                {
                    AnyProp = Guid.NewGuid().ToString(),
                    Child1 = new Child1() { AnyProp = @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent dignissim odio purus, vitae suscipit erat eleifend et. Suspendisse magna sapien, eleifend nec blandit non, tincidunt in sapien. Praesent congue molestie venenatis. Mauris non dolor pretium, facilisis justo eget, tristique nunc. Fusce at semper nibh. Sed fringilla ac ex id mollis. Suspendisse potenti. Ut viverra facilisis rhoncus. Pellentesque ac leo eget enim pretium faucibus. Nullam dictum congue blandit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Cras sed tortor ex. Morbi dui dolor, dictum ultricies nulla a, molestie imperdiet eros. Vivamus est lectus, dignissim ut porttitor vel, rutrum nec libero. Aenean placerat ultricies rhoncus.
Aliquam interdum purus tortor, eu dictum nunc dapibus id. Ut consectetur, mi auctor finibus venenatis, nibh nisl porta tortor, eget ornare turpis elit et orci. Sed vel porta nulla. Ut tincidunt sapien sit amet risus ultricies porttitor. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla massa lectus, blandit vel lobortis ac, tincidunt eu dui. Curabitur dolor odio, vehicula nec tellus eu, mollis posuere massa. Ut venenatis eget mi ut gravida. Duis vel odio efficitur, tincidunt nunc ut, cursus purus.
Cras maximus diam in mauris mattis, at consequat tortor aliquam. Sed ligula ligula, volutpat et pharetra eget, gravida at diam. Sed vulputate magna tristique, viverra eros dapibus, interdum tortor. Phasellus eleifend placerat faucibus. Mauris posuere ut urna nec ultrices. Ut sed mauris et risus ultricies tincidunt sit amet at dolor. Aliquam vulputate urna sit amet elit auctor, nec condimentum sem pharetra. Duis eget condimentum nisl. Duis in velit sem.
In nunc sapien, maximus a orci quis, pretium imperdiet neque. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Mauris interdum porttitor imperdiet. Quisque gravida porttitor massa, a vulputate augue ornare varius. Aenean aliquet mollis ante, ac rutrum ligula facilisis vitae. Donec pretium sapien ut tempus iaculis. Vestibulum mattis leo et ex venenatis, pharetra dictum nibh pulvinar. Nullam luctus lorem ante, id semper nisl interdum vel. Pellentesque semper dui quis venenatis semper. Maecenas pulvinar mi sapien. Suspendisse euismod nisi vel aliquam eleifend.
Nullam ullamcorper porta mauris, quis porttitor magna scelerisque vitae. Cras et sapien et mi interdum molestie. Quisque auctor ultrices lectus, vitae gravida ligula fringilla a. In hac habitasse platea dictumst. Phasellus vitae mi fermentum, maximus ligula et, aliquet dolor. Praesent eleifend ut nisl nec interdum. Ut porttitor diam a tellus fermentum, non efficitur purus eleifend. Sed et quam a nibh finibus pulvinar. Quisque luctus, purus at fringilla ullamcorper, purus nulla pulvinar lacus, eget posuere tellus ipsum quis quam. Donec sit amet euismod nibh. Curabitur vehicula ipsum quis varius vestibulum.
Nullam sagittis quis orci nec maximus. In bibendum lorem non tortor mollis, vel auctor tortor suscipit. Phasellus consectetur velit at ligula pulvinar, sagittis congue risus dictum. Mauris id condimentum felis. Quisque et libero nec mauris imperdiet mattis. Integer laoreet magna pharetra laoreet efficitur. Curabitur vel elementum enim. In sed sem id lorem porta tristique. Donec euismod, nunc et luctus semper, nunc ante malesuada justo, quis consequat arcu libero consequat ante. Proin elementum fermentum est id mollis.
Aenean purus quam, molestie sed erat in, bibendum viverra lectus. Praesent aliquet, nibh ac sodales ullamcorper, est turpis mollis odio, vitae accumsan sem lacus et nunc. Suspendisse eleifend maximus sagittis. Etiam tempus mauris risus, id lobortis risus mattis non. Integer dictum erat eu ex bibendum rutrum. Mauris lacinia diam at lacus commodo consectetur. Etiam consectetur magna purus, id ultrices tellus porttitor sit amet. Sed interdum finibus posuere. Aenean euismod dolor in est feugiat, aliquam finibus mauris dignissim. Nulla sed laoreet nisi. Morbi facilisis massa porta nisi consectetur dignissim. Duis suscipit massa sed sem lobortis, at condimentum est cursus. Curabitur at posuere nisi. Donec accumsan odio id quam tempor aliquam. In aliquam, nisi non interdum congue, enim enim sagittis felis, ut bibendum turpis metus quis tellus. Quisque cursus aliquam facilisis.
Nulla urna ex, vehicula vel semper id, ullamcorper sit amet ligula. Praesent tempor odio vel magna vulputate, a volutpat turpis gravida. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras tempus suscipit porttitor. Pellentesque vel orci sit amet risus facilisis convallis sed auctor leo. Sed ut lacus ornare, venenatis tellus nec, molestie nisl. Sed massa dolor, volutpat a tincidunt quis, imperdiet quis erat.
Nam ornare turpis non orci tincidunt placerat. Aenean non purus at nisl fermentum luctus quis sed nibh. Integer commodo odio sit amet felis efficitur pharetra eget ac leo. Duis ac massa nec quam cursus pellentesque sit amet vel elit. Ut at ante turpis. Vestibulum posuere felis libero, non tempor lacus interdum quis. Vestibulum fringilla nisl vitae urna convallis lobortis. Nullam facilisis dignissim lacinia. Suspendisse ullamcorper magna sed tellus vehicula congue. Cras purus lectus, rhoncus sed neque in, fermentum euismod nisi. Ut ornare ligula ante, eget finibus neque vestibulum vel. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nulla facilisi. Morbi sit amet aliquam libero. Pellentesque ut semper arcu. Aliquam erat volutpat.
Nunc eget lacus massa. Aenean gravida ipsum eget congue dignissim. Donec tempor pretium venenatis. Pellentesque ac pharetra odio. Ut ultricies ac urna in consectetur. Phasellus rhoncus aliquet metus, nec ullamcorper ipsum pretium ultricies. Nunc suscipit, justo eget tempus vestibulum, leo quam accumsan ligula, in consectetur ante magna quis massa. Ut maximus sem eget ex interdum commodo. Ut interdum tellus vel neque convallis dictum. Integer ullamcorper accumsan eleifend. Donec rhoncus pretium cursus.
Duis eu blandit sapien, sed feugiat neque. Suspendisse neque diam, sagittis et maximus et, elementum sit amet libero. Sed non odio dolor. Sed quis malesuada quam. Aliquam et ante lobortis, ultrices leo id, porttitor erat. Morbi dapibus lacinia quam nec iaculis. Fusce volutpat massa ut odio mattis finibus vitae id mi. Vivamus eu congue enim, nec dignissim sapien.
Vivamus maximus est eget risus tempus, eu venenatis velit vehicula. Integer dapibus accumsan massa feugiat consequat. Proin non turpis lectus. Duis bibendum a felis a porta. Quisque blandit nulla ut gravida bibendum. Phasellus pulvinar velit vitae lorem ornare cursus vel cursus metus. Praesent varius massa sed sapien convallis dignissim. Aenean suscipit id leo a ultrices. Vivamus quis gravida dui. Fusce nec metus sit amet diam ultricies faucibus faucibus pharetra risus.
Nunc commodo lorem sed sapien interdum, at egestas ipsum molestie. Aliquam erat volutpat. Nunc ex mauris, ultricies faucibus lectus sed, posuere efficitur justo. Nunc nunc ante, venenatis id erat mattis, cursus venenatis nisi. Vivamus et massa justo. Cras luctus ullamcorper lorem, mattis rutrum urna auctor vitae. Etiam at magna quis urna tincidunt pretium vitae sit amet purus. Aliquam consequat orci est, quis sollicitudin ipsum eleifend in. Praesent dictum nibh vel ullamcorper posuere. Nam imperdiet et massa a convallis. Maecenas lacinia libero eget dui tincidunt commodo. Nullam lobortis arcu tellus, non faucibus nibh dictum ac.
Morbi in consequat odio, et finibus tortor. Donec dignissim ac est vel aliquet. Ut purus magna, semper ut augue quis, vehicula porttitor erat. Nulla hendrerit quam nec varius consectetur. Vestibulum sit amet erat mi. Aliquam vel augue tristique sapien suscipit gravida quis eu sem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. In efficitur augue at tellus commodo, feugiat suscipit massa tempor.
Aliquam sed porta erat. Cras bibendum metus fermentum dolor tempus semper. Sed bibendum mi vitae lectus fermentum, vel scelerisque quam eleifend. Sed vestibulum erat id sagittis finibus. Mauris ornare tellus pellentesque, rhoncus ligula ac, ornare metus. Fusce sodales metus nec risus efficitur vulputate. Proin suscipit eleifend nunc, et aliquam est lobortis sit amet. Nunc magna erat, mollis eu faucibus et, commodo at erat. Vestibulum volutpat ac felis eu accumsan. Duis id dolor in erat hendrerit auctor ac at lectus. Phasellus ipsum metus, fermentum vitae erat eget, dictum dapibus mauris.
Fusce tristique elit eget est consequat, vel scelerisque ipsum venenatis. Cras ac leo et metus tincidunt fermentum. Etiam in venenatis est. Sed vel turpis eget nibh ornare tristique scelerisque eget diam. Fusce diam erat, ornare et feugiat sed, scelerisque in lectus. Sed pellentesque ipsum a vestibulum fermentum. Pellentesque at commodo felis, eu malesuada lacus. Sed egestas scelerisque odio, ut rutrum ligula interdum non. Praesent consequat sapien ut egestas facilisis. Etiam vulputate id turpis vel molestie.
Donec eleifend, lorem dignissim convallis aliquet, elit nisl tincidunt justo, nec consequat ex neque ac lacus. Ut cursus bibendum scelerisque. Pellentesque ac euismod mi. Sed ac semper erat. Curabitur volutpat, libero a elementum viverra, nulla quam commodo nibh, at sodales massa quam eu neque. In id erat dui. Praesent lacinia consectetur augue ut pulvinar. Quisque ac nibh in nibh volutpat ultrices et ac tellus. Phasellus aliquam tristique sem, sit amet tristique ipsum eleifend eget. Nullam bibendum suscipit tortor pellentesque facilisis. Vivamus vitae sollicitudin quam, sed condimentum est.
Sed eleifend, lectus eu viverra varius, quam nibh malesuada neque, nec venenatis urna augue a ligula. In porttitor lacinia leo vel cursus. Donec convallis ac purus non condimentum. Duis non porttitor felis. Vestibulum condimentum est magna, ut dapibus lacus placerat et. Vestibulum suscipit odio ligula, id varius eros convallis id. Nunc massa magna, ultricies gravida felis ut, semper ullamcorper diam. Sed venenatis cursus tristique. Proin accumsan pellentesque quam ac pretium. Aliquam vehicula vulputate augue eu porta. Aliquam hendrerit velit tellus, sed laoreet enim dictum non. Etiam in placerat diam, at blandit diam. Nulla vel lorem non nibh interdum convallis. Aenean aliquet ligula neque, nec iaculis dui accumsan et. Lorem ipsum dolor sit amet, consectetur adipiscing elit.
Interdum et malesuada fames ac ante ipsum primis in faucibus. Phasellus lobortis tellus sagittis lectus cursus, ac aliquam velit ornare. Nam nisl sapien, euismod ac consequat non, sagittis sed lorem. Morbi sit amet tristique neque. Integer cursus, nunc quis interdum vulputate, dui nulla gravida nisi, nec accumsan ex justo at ligula. Aenean ultricies vitae ex non gravida. Morbi dapibus posuere placerat. In et lacus metus. Aliquam vulputate mauris sit amet nibh egestas, nec posuere nisl congue.
Mauris felis turpis, feugiat a erat quis, vestibulum dapibus quam. Mauris feugiat at neque sed consequat. Vestibulum eget hendrerit sapien. Vestibulum sit amet elit nisl. Etiam at mattis arcu, ac pharetra tellus. Nam vitae lectus a massa posuere blandit. Proin ac mauris odio. Praesent quis nunc posuere, efficitur nunc eget, iaculis nunc. Nunc ipsum tortor, interdum elementum posuere id, consequat vitae mi. Praesent id tortor placerat, tempor urna vitae, facilisis eros. Mauris ultrices rutrum nisl eget condimentum. Nunc nibh sem, euismod at posuere at, accumsan imperdiet tortor. Suspendisse eros tellus, porttitor eu felis eget, gravida posuere lectus. In scelerisque, libero non varius suscipit, tellus odio dictum nibh, et cursus tortor nunc id mi.
Curabitur non risus cursus, ultrices sem quis, lacinia sapien. Aenean vitae urna lacus. Morbi lacinia mattis tellus, et tempus ipsum viverra pretium. Donec bibendum, odio pharetra varius porta, eros purus tincidunt leo, at pretium nisl elit et ligula. Quisque dignissim enim arcu, eu vestibulum ex efficitur vel. Nunc ac nisi eu arcu pretium congue. Quisque nec tortor ut justo ultrices gravida sed sit amet ante. Donec aliquet neque at enim viverra, eget imperdiet augue pharetra.
Suspendisse potenti. Quisque ligula velit, imperdiet at vulputate vitae, aliquet et nisl. Integer vel euismod nibh. Etiam non augue vel ante ultricies varius at ac ipsum. Etiam ut sem a massa viverra euismod gravida vel arcu. Phasellus eget quam id enim volutpat lacinia. Proin elementum sapien ut mauris ullamcorper, ut interdum ipsum viverra. Proin rhoncus non purus in venenatis.
Nullam a lacinia nulla. Integer efficitur lectus eu purus mattis vulputate. Fusce mattis porta semper. Nullam gravida molestie orci, ut eleifend ipsum sagittis quis. Maecenas vel augue sed elit gravida cursus non at quam. Integer elit lectus, faucibus in leo ac, feugiat molestie nulla. Mauris commodo blandit dolor, eget suscipit lorem aliquam sit amet. Nulla magna eros, vehicula ac dolor eu, aliquet blandit elit. Etiam ex justo, hendrerit eu consequat id, aliquet quis enim.
Vestibulum sed magna eget dolor gravida vulputate. Duis pretium, sem in sollicitudin aliquam, erat nisi vestibulum magna, eget commodo mauris augue eget est. Ut a tellus nec quam ullamcorper ultrices et ut ex. Curabitur vitae neque consectetur, cursus orci quis, accumsan ipsum. Etiam porta nunc leo, sed pharetra lorem pretium id. Nunc ac est orci. Vivamus odio magna, semper id velit quis, tempus sollicitudin quam. Donec luctus semper fermentum. Donec vitae velit pharetra, condimentum sapien eu, tempus nisl. Suspendisse consectetur porta lorem, sit amet vestibulum magna tristique sed. Integer sed venenatis turpis, at iaculis nisl. Donec pellentesque gravida orci in malesuada.
In eget quam interdum, consectetur turpis ac, ultricies nunc. Curabitur sed porttitor felis. Cras a condimentum sapien. Morbi commodo turpis eu nibh eleifend, in volutpat mi porta. Curabitur tempus nunc sodales, consectetur sapien vitae, venenatis diam. Phasellus a dui aliquet, semper enim pharetra, iaculis odio. Praesent rutrum arcu ac dolor imperdiet, non consectetur dui fermentum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Sed fermentum augue odio, a fermentum nisi viverra quis. Nulla quis diam vestibulum, auctor nisi quis, ornare massa. Sed odio odio, aliquet quis facilisis vel, aliquet ut massa. Donec pretium fringilla tortor accumsan molestie. Praesent lacinia finibus mollis. Duis malesuada maximus tincidunt. Nullam tellus lectus, semper eget ipsum sit amet, efficitur tincidunt dolor. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.
Pellentesque ac luctus erat. Aenean sed nunc purus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla nisl sapien, laoreet ut mi non, pretium interdum quam. Nunc facilisis luctus arcu, in pulvinar diam tristique eget. Nam id enim eu lacus egestas fringilla. Proin lacus metus, porta et dapibus et, auctor non felis. Suspendisse ac felis scelerisque, finibus nibh sit amet, mollis lorem. Duis vitae ante accumsan, iaculis quam eu, semper tortor.
Pellentesque rutrum commodo tempor. In vehicula quis velit non blandit. Duis at fermentum turpis. Phasellus et risus in dolor suscipit efficitur. Nunc fringilla leo id erat porta lobortis. Aliquam convallis felis et elementum dapibus. Sed ullamcorper quam rhoncus dui pellentesque elementum. Donec dictum viverra magna sed condimentum. Maecenas imperdiet eros a ex volutpat fermentum. Aliquam in velit leo. Cras at elementum lacus. Praesent blandit velit placerat, sodales tortor placerat, laoreet lectus. Nullam sit amet orci eget justo tincidunt condimentum. Duis sit amet accumsan turpis.
" },
                    Child2 = new Child2() { AnyProp = Guid.NewGuid().ToString() },
                    Child3 = new List<Child3>
                    {
                        new Child3() { AnyProp = Guid.NewGuid().ToString() },
                        new Child3() { AnyProp = Guid.NewGuid().ToString() },
                        new Child3() { AnyProp = Guid.NewGuid().ToString() },
                    }
                };

                entities.Add(model);
            }

                await dbContext.AddRangeAsync(entities);
                await dbContext.SaveChangesAsync();


            return Result.Success();
        }

        public static IEnumerable<IEnumerable<TSource>> ToChunk<TSource>(IEnumerable<TSource> source, int chunkSize)
        {
            while (source.Any())
            {
                yield return source.Take(chunkSize);
                source = source.Skip(chunkSize);
            }
        }
    }
}
