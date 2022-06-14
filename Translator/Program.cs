using Westwind.Globalization;
using Newtonsoft.Json;

Console.WriteLine("Translating entity names into russian one");
TranslationServices service = new TranslationServices();

List<string[]>[] entities =
{
    new List<string[]>
    {
        new string[] { "Department" },
        new string[] {"DepartmentName", "DepartmentDescription"},
    },
    new List<string[]>
    {
        new string[] { "Groups" },
        new string[] {"GroupName", "GroupSpeciality"},
    },
    new List<string[]>
    {
        new string[] { "Users" },
        new string[] {"UserLogin", "UserFIO", "UserPassword"},
    },
    new List<string[]>
    {
        new string[] { "UserRoles" },
        new string[] {"RoleName", "UserRoleID"},
    }
};
Console.WriteLine(entities[0][0][0]);
foreach (var entity in entities)
{       
    foreach (var item in entity)
    {
        foreach (var word in item) Console.WriteLine(service.TranslateGoogle(word, "en", "ru"));
    }
}

Console.WriteLine();

Console.WriteLine();
Console.ReadKey();