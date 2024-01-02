using DeliveryProject.Domain.Entities;
using DeliveryProject.Persistence.Data;
using Elkood.Identity.Entities;
using Elkood.Identity.Mangers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pipelines.Sockets.Unofficial.Arenas;
using PuppeteerSharp;
using StackExchange.Redis;

namespace DeliveryProject.Persistence.Seed;

public static class DataSeed
{
    public static async Task Seed(AppDbContext context, IServiceProvider serviceProvider)
    {
        await ProductionSeed(context, serviceProvider);
    }

    private static async Task ProductionSeed(AppDbContext context, IServiceProvider serviceProvider)
    {
        //var userManager = serviceProvider.GetRequiredService<ElUserManager<User>>();
        //var roleManager = serviceProvider.GetRequiredService<ElRoleManager<ElIdentityRole>>();
        var connectionMultiplexer = serviceProvider.GetRequiredService<IConnectionMultiplexer>();
        context.ChangeTracker.Clear();
        //SeedWwwroot(context);
        //await SeedInitial(context, connectionMultiplexer);
        //await SeedSecurity(userManager, roleManager, context);
        //await SeedNotifications(context);
        //await SeedAds(context);
        //await SeedHomeAds(context);
        //await SeedContactUs(context);
    }

    private static async Task SeedInitial(AppDbContext context, IConnectionMultiplexer connectionMultiplexer)
    {
        //if (context.Cities.Any()) return;

        //context.DurationOfDays.AddRange(ConstValues.DurationOfDays);

        await ClearRedis(connectionMultiplexer);
        //context.Add(Setting.Seed());
        //await context.AddWithTranslateAsync(new AboutApp("Look Who are ... we are dreamers", "Elan Company",
        //    "Elan info"));

        //await context.AddWithTranslateAsync(new City("مدينة افتراضيه2"));
        await context.SaveChangesAsync();


        //var city = City.SeedUndefined();
        //await context.AddWithTranslateAsync(city);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();
        //await context.AddWithTranslateAsync(Area.SeedUndefined(city.Id));
        //await context.AddWithTranslateAsync(new Preference("طعام", AddImage())); //seed preference
        //await context.AddWithTranslateAsync(new Preference("تقنية", AddImage()));
        //await context.AddWithTranslateAsync(new Preference("رياضة", AddImage()));

        //await context.AddWithTranslateAsync(new Area("منطقه افتراضيه1", city.Id)); //seed area
        //await context.AddWithTranslateAsync(new Area("منطقه افتراضيه2", city.Id));

        //await context.AddWithTranslateAsync(new CompanyCategory("غذائيه")); //seed companyCategory
        //await context.AddWithTranslateAsync(new CompanyCategory("دوائية"));

        //await context.AddWithTranslateAsync(new Interest("الطبخ")); //seed Interest
        //await context.AddWithTranslateAsync(new Interest("البرمجة"));

        //await context.AddWithTranslateAsync(new Education("هندسة معلوماتية")); //seed Education
        //await context.AddWithTranslateAsync(new Education("هندسة مدنية"));

        //context.Add(new BalanceCard(100, 100, BalanceServiceProvider.Syriatel));
        //context.Add(new BalanceCard(100, 100, BalanceServiceProvider.Mtn));

        //var subscription = new Subscription("default Normal", 150, 10_000, PointsType.Normal,
        //    new DurationValueObject(DurationType.Week, 7));
        //var subscription2 = new Subscription("Products", 150, 10_000, PointsType.Products,
        //    new DurationValueObject(DurationType.Week, 7));
        //await context.AddWithTranslateAsync(subscription);
        //await context.AddWithTranslateAsync(subscription2);

        //var customerSupportLink = new CustomerSupportLink(SocialMediaType.Facebook, "www.facebook.com");
        //var customerSupportLink2 = new CustomerSupportLink(SocialMediaType.Linkedin, "www.Linkedin.com");
        //context.AddRange(customerSupportLink, customerSupportLink2);

        await context.SaveChangesAsync();
    }

    private static async Task ClearRedis(IConnectionMultiplexer connectionMultiplexer)
    {
        var database = connectionMultiplexer.GetDatabase();
        var server = connectionMultiplexer.GetServer(connectionMultiplexer.GetEndPoints().First());
        var keys = await server.KeysAsync(pattern: connectionMultiplexer.ClientName + "*").ToArrayAsync();
        await database.KeyDeleteAsync(keys);
    }

    //private static async Task SeedSecurity(ElUserManager<User> userManager, ElRoleManager<ElIdentityRole> roleManager,
    //    ElanDbContext context)
    //{
    //    if (context.Users.Any()) return;

    //    var role = new ElIdentityRole("default"); //seed default role
    //    await roleManager.CreateAsync(role);

    //    var cityId = (await context.Cities.Where(c => c.Areas.Any()).FirstAsync()).Id;
    //    var areaId = (await context.Areas.Where(a => a.CityId == cityId).FirstAsync()).Id;

    //    var owner = Employee.SeedOwner(cityId, AddImage(), new List<string>() { AddImage() });
    //    owner.AddOwnerClaim();
    //    var identityResult = await userManager.CreateAsync(owner, "1234");

    //    var admin = Employee.SeedAdmin(cityId, AddImage(), new List<string>() { AddImage() });
    //    identityResult = await userManager.CreateAsync(admin, "1234");
    //    identityResult = await userManager.AddToRoleAsync(admin, "default");

    //    var mobileUser = MobileUser.Seed(AddImage());
    //    mobileUser.AddAddress(areaId);
    //    await userManager.CreateAsync(mobileUser, "1234");
    //    // await userManager.UpdateAsync(mobileUser);

    //    var advertiser = Advertiser.Seed(
    //        mobileUser.Id,
    //        (await context.CompanyCategories.FirstAsync()).Id,
    //        (await context.Areas.FirstAsync()).Id,
    //        new List<string>() { AddImage() });
    //    context.Add(advertiser);
    //    mobileUser.SetAdvertiserId(advertiser.Id);
    //    await userManager.UpdateAsync(mobileUser);
    //}

    private static async Task SeedNotifications(AppDbContext context)
    {
        //if (context.DashNotifications.Any()) return;
        //await context.AddRangeAsync(new DashNotification("1", null),
        //    new DashNotification("2", null),
        //    new DashNotification("3", null));
        await context.SaveChangesAsync();
    }

    private static async Task SeedAds(AppDbContext context)
    {
        //if (context.Ads.Any()) return;
        //var advertiser = await context.Advertisers.FirstAsync();

        //var product = new Product("default", advertiser.Id);
        //context.Add(product);

        //await foreach (var subscription in context.Subscriptions)
        //{
        //    var advertiserSubscription = AdvertiserSubscription.Seed(advertiser.Id, subscription);
        //    context.AdvertiserSubscriptions.Add(advertiserSubscription);
        //}

        await context.SaveChangesAsync();

        //var ad = Ad.Seed(advertiser.Id, context.DurationOfDays.Select(d => d.Id).ToList());

        //context.Ads.Add(ad);

        await context.SaveChangesAsync();
    }

    private static async Task SeedContactUs(AppDbContext context)
    {
        //if (context.ContactUses.Any())
        //{
        //    return;
        //}

        //var mobileUserId = context.MobileUsers.First().Id;
        //var contactUs = new ContactUs("title", "contact", mobileUserId);
        //await context.AddAsync(contactUs);

        await context.SaveChangesAsync();
    }

    // private static async Task SeedHomeAds(ElanDbContext context)
    // {
    //     if (context.DurationOfDays.Any()) return;
    //
    //     context.AddRange(ConstValues.DurationOfDays);
    //
    //     await context.SaveChangesAsync();
    // }   

    private static async Task SeedHomeAds(AppDbContext context)
    {
        //if (context.HomeAds.Any()) return;

        //var advertiserId = context.Advertisers.First().Id;
        //context.AddRange(new List<HomeAd>()
        //{
        //    new(AddImage(),"google.com", DateTime.Now.AddMonths(3), DateTime.Now, 1, "name1", advertiserId),
        //    new(AddImage(),null, DateTime.Now.AddMonths(3), DateTime.Now, 2, "name2", advertiserId),
        //    new(AddImage(),"facebook.com", DateTime.Now.AddMonths(3), DateTime.Now, 3, "name3", advertiserId),
        //});
        await context.SaveChangesAsync();
    }

    #region - Base -

    // private static string AddImage()
    // {
    //     var s = Path.Combine(Directory.GetCurrentDirectory(), ConstValues.ElkoodJpg);
    //     var x = Path.Combine(ConstValues.Seed, Guid.NewGuid() + "_" + ConstValues.ElkoodJpg);
    //     var d = Path.Combine(Directory.GetCurrentDirectory(), ConstValues.WwwrootDir, x);
    //     File.Copy(s, d);
    //     return x;
    // }

    //private static string AddImage()
    //{
    //    //return ConstValues.SeedImageS3;
       
    //}

    private static void SeedWwwroot(AppDbContext context)
    {
        if (context.Users.Any())
        {
            return;
        }

        //if (Directory.Exists(ConstValues.WwwrootDir))
        //{
        //    Directory.Delete(ConstValues.WwwrootDir, true);
        //}

        System.IO.Compression.ZipFile.ExtractToDirectory("wwwroot.zip", Directory.GetCurrentDirectory());
    }

    #endregion
}