using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyAPI.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "https://photosa.propertyimages.ie/media/2/3/2/4292232/e0c4c2c8-6a61-4fda-b5a8-59edc32060b6_l.jpg");

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "PropertyId", "Url" },
                values: new object[,]
                {
                    { 3, 4292232, "https://photosa.propertyimages.ie/media/2/3/2/4292232/b5ce3372-d71c-4897-91dc7c5b4ce21c17_l.jpg" },
                    { 23, 4284885, "https://photosa.propertyimages.ie/media/5/8/8/4284885/f85794ff-5714-4247-91a0-08eed0853a46_l.jpg" },
                    { 24, 4284885, "https://photosa.propertyimages.ie/media/5/8/8/4284885/1e2309b8-8fa3-4315-bf20-488d5532856b_l.jpg" },
                    { 26, 4284885, "https://photosa.propertyimages.ie/media/5/8/8/4284885/9100e307-c3dc-468c-bbfc4e0509cf69be_l.jpg" },
                    { 27, 4301244, "https://photosa.propertyimages.ie/media/4/4/2/4301244/dcacf01c-089b-4d54-b452-eb0d9cb9de4d_l.jpg" },
                    { 28, 4301244, "https://photosa.propertyimages.ie/media/4/4/2/4301244/e60480c8-a834-41ee-8250-9d2c97ba249e_l.jpg" },
                    { 29, 4301244, "https://photos-a.propertyimages.ie/media/8/9/2/3851298/44915955-f480-4f3d-8e42-84f12ebfbfde_l.jpg" },
                    { 30, 4301244, "https://photosa.propertyimages.ie/media/8/9/2/3851298/d8874610-f7ca-4e2b-b450-1dd19597ff0c_l.jpg" },
                    { 31, 4301244, "https://photosa.propertyimages.ie/media/8/9/2/3851298/3360cd3a-d478-47ab-94b0-f1bd30361dda_l.jpg" },
                    { 32, 4301243, "https://photosa.propertyimages.ie/media/3/4/2/4301243/4453564d-ffa4-4e58-af73-04104692e3cd_l.jpg" },
                    { 33, 4301243, "https://photos-a.propertyimages.ie/media/8/9/2/3851298/9991fa79-d54d-4c0d-a753-23838287e215_l.jpg" },
                    { 34, 4301243, "https://photos-a.propertyimages.ie/media/8/9/2/3851298/9b15a341-5698-4d8a-9849-a8d2df6f4bef_l.jpg" },
                    { 35, 4301243, "https://photosa.propertyimages.ie/media/3/4/2/4301243/b7a48e74-ff8a-436d-af3a4eb2ed0c47de_l.jpg" },
                    { 36, 4301242, "https://photosa.propertyimages.ie/media/2/4/2/4301242/4c9ea054-1865-4bd3-901a6ad05a79fa7e_l.jpg" },
                    { 37, 4301242, "https://photosa.propertyimages.ie/media/2/4/2/4301242/f08c8c5d-731d-4be3-a78ee3501d1214d6_l.jpg" },
                    { 22, 4301245, "https://photosa.propertyimages.ie/media/5/4/2/4301245/7c4d1310-c0c6-4403-97e0-ecc84e564605_l.jpg" },
                    { 21, 4301245, "https://photosa.propertyimages.ie/media/5/4/2/4301245/0eade5e7-95b6-43dc-a22da12ec5e37159_l.jpg" },
                    { 25, 4284885, "https://photosa.propertyimages.ie/media/5/8/8/4284885/394f3834-3ccd-4185-9eeeaf6686004801_l.jpg" },
                    { 19, 4301245, "https://photosa.propertyimages.ie/media/5/4/2/4301245/c6756ace-04b6-4701-b80bbb74f9b985de_l.jpg" },
                    { 4, 4229499, "https://photosa.propertyimages.ie/media/9/9/4/4229499/aae25e08-31b0-465b-ba35-498d78f6b5c9_l.jpg" },
                    { 5, 4229499, "https://photosa.propertyimages.ie/media/9/9/4/4229499/7f983103-2529-425a-905b617b23bfa0f7_l.jpg" },
                    { 20, 4301245, "https://photosa.propertyimages.ie/media/5/4/2/4301245/7976ee5f-3dc0-4874-833dc169cd0e2ef9_l.jpg" },
                    { 7, 4301249, "https://photosa.propertyimages.ie/media/9/4/2/4301249/0e9bc081-ab16-4885-bddbf33678432a17_l.jpg" },
                    { 8, 4301249, "https://photosa.propertyimages.ie/media/9/4/2/4301249/2e03ba2b-471d-4f93-a8ad6bfecd2fd35b_l.jpg" },
                    { 9, 4301247, "https://photosa.propertyimages.ie/media/7/4/2/4301247/7ff064ce-07c2-4a34-8765-d031b7a28295_l.jpg" },
                    { 10, 4301247, "https://photosa.propertyimages.ie/media/7/4/2/4301247/ecd5bd19-e956-4c04-9932-0cf0112bb2f6_l.jpg" },
                    { 6, 4229499, "https://photosa.propertyimages.ie/media/9/9/4/4229499/4470fb1c-c301-4b1c-8bfae1c85a5d8fbc_l.jpg" },
                    { 12, 4301247, "https://photosa.propertyimages.ie/media/7/4/2/4301247/be1c10b1-d7be-4c97-890dc8759f288881_l.jpg" },
                    { 13, 4301246, "https://photosa.propertyimages.ie/media/6/4/2/4301246/90ef0a16-59e7-410c-b688-f45361fc00df_l.jpg" },
                    { 14, 4301246, "https://photosa.propertyimages.ie/media/6/4/2/4301246/2066a03f-d26a-4ceb-92ddd0247556c803_l.jpg" },
                    { 15, 4301246, "https://photosa.propertyimages.ie/media/6/4/2/4301246/a28bd769-e544-468f-8fa6-e590a3ed77c0_l.jpg" },
                    { 16, 4301246, "https://photosa.propertyimages.ie/media/6/4/2/4301246/183b8fa1-33d1-4bcb-91ae696f51c08935_l.jpg" },
                    { 17, 4301246, "https://photosa.propertyimages.ie/media/6/4/2/4301246/8e15e93c-c64e-4306-a18fa276858b25da_l.jpg" },
                    { 18, 4301245, "https://photosa.propertyimages.ie/media/5/4/2/4301245/a8fc46c4-6676-4e82-89cf74c1736ce441_l.jpg" },
                    { 11, 4301247, "https://photosa.propertyimages.ie/media/7/4/2/4301247/94b223ea-a365-4646-966d90743344a5d0_l.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4292232,
                columns: new[] { "BedsString", "DisplayAddress" },
                values: new object[] { "2	beds", "Apt.	16	The	Northumberlands,	Off	Lower	Mount	Street," });

            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "Id", "BedsString", "BerRating", "DisplayAddress", "GroupLogoUrl", "MainPhoto", "Price", "PropertyType", "SizeStringMeters" },
                values: new object[,]
                {
                    { 4301247, "4 beds", "C1", "Cappagh,	Inistioge,	Co	Kilkenny,	R95	E642", "https://photosa.propertyimages.ie/groups/0/5/6/5650/logo.jpg", "https://photosa.propertyimages.ie/media/7/4/2/4301247/7ff064ce-07c2-4a34-8765-d031b7a28295_l.jpg", 550000, "Detached	House", 238.40000000000001 },
                    { 4301246, "3	beds", null, "4	Rices	Street,	Dungarvan,	Waterford", "https://photosa.propertyimages.ie/groups/8/6/9/8968/logo.jpg", "https://photosa.propertyimages.ie/media/6/4/2/4301246/90ef0a16-59e7-410c-b688-f45361fc00df_l.jpg", 135000, "End	of	Terrace	House", 0.0 },
                    { 4301245, "3	beds", null, "Cloghan	Road,	Shannonbridge,	Offaly", "https://photosa.propertyimages.ie/groups/9/9/5/309599/logo.jpg", "https://photosa.propertyimages.ie/media/5/4/2/4301245/a8fc46c4-6676-4e82-89cf74c1736ce441_l.jpg", 0, "Bungalow", 109.0 },
                    { 4284885, "4	beds", "D1", "45	Ardmore,	Gorey,	Wexford", "https://photosa.propertyimages.ie/groups/3/1/4/256413/logo.jpg", "https://photosa.propertyimages.ie/media/5/8/8/4284885/f85794ff-5714-4247-91a0-08eed0853a46_l.jpg", 325000, "Detached	House", 0.0 },
                    { 4301244, "3	beds", null, "21	Derryounce,	Portarlington,	Co.	Laois", "https://photosa.propertyimages.ie/groups/7/0/1/259107/logo.jpg", "https://photosa.propertyimages.ie/media/4/4/2/4301244/dcacf01c-089b-4d54-b452-eb0d9cb9de4d_l.jpg", 200000, "End	of	Terrace	House", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "Id", "BedsString", "BerRating", "DisplayAddress", "GroupLogoUrl", "MainPhoto", "Price", "PropertyType", "SizeStringMeters" },
                values: new object[,]
                {
                    { 4301243, "3	beds", null, "22	Derryounce,	Portarlington,	Co.	Laois", "https://photosa.propertyimages.ie/groups/7/0/1/259107/logo.jpg", "https://photosa.propertyimages.ie/media/3/4/2/4301243/4453564d-ffa4-4e58-af73-04104692e3cd_l.jpg", 260000, "Terraced	House", 0.0 },
                    { 4301242, "3	beds", null, "23	Derryounce,	Portarlington,	Co.	Laois", "https://photosa.propertyimages.ie/groups/7/0/1/259107/logo.jpg", "https://photosa.propertyimages.ie/media/2/4/2/4301242/4c9ea054-1865-4bd3-901a6ad05a79fa7e_l.jpg", 200000, "Terraced	House", 0.0 },
                    { 4229499, "5	beds", "B2", "Alleen,	Donohill,	Tipperary", "https://photosa.propertyimages.ie/groups/9/2/6/283629/logo.jpg", "https://photosa.propertyimages.ie/media/9/9/4/4229499/aae25e08-31b0-465b-ba35-498d78f6b5c9_l.jpg", 420000, "Detached	House", 98.0 },
                    { 4301249, "2	beds", "G", "20	Gratton	Street,	Gorey,	Wexford", "https://photosa.propertyimages.ie/groups/3/1/4/256413/logo.jpg", "https://photosa.propertyimages.ie/media/9/4/2/4301249/0e9bc081-ab16-4885-bddbf33678432a17_l.jpg", 99000, "Terraced	House", 0.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4229499);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4284885);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4301242);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4301243);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4301244);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4301245);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4301246);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4301247);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4301249);

            migrationBuilder.UpdateData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 2,
                column: "Url",
                value: "https://photosa.propertyimages.ie/media/2/3/2/4292232/38e98b8e-645f-4adf-8e57-f927e5769840_l.jpg");

            migrationBuilder.UpdateData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4292232,
                columns: new[] { "BedsString", "DisplayAddress" },
                values: new object[] { "2 beds", "Apt. 16 The Northumberlands, Off Lower Mount Street Dublin 2" });
        }
    }
}
