using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Timezone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DvdCountries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Timezone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DvdCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Externals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tvrage = table.Column<int>(nullable: true),
                    Thetvdb = table.Column<int>(nullable: true),
                    Imdb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Externals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medium = table.Column<string>(nullable: true),
                    Original = table.Column<string>(nullable: true),
                    TvShowId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelfHref = table.Column<string>(nullable: true),
                    PreviousepisodeHref = table.Column<string>(nullable: true),
                    TvShowId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Average = table.Column<double>(nullable: true),
                    TvShowId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(nullable: true),
                    TvShowId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    OfficialSite = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Networks__Countr__2F10007B",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebChannels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    OfficialSite = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK__WebChanne__Count__48CFD27E",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Previousepisodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Href = table.Column<string>(nullable: true),
                    LinksId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Previousepisodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Previouse__Links__403A8C7D",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Selves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Href = table.Column<string>(nullable: true),
                    LinksId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selves", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Selves__LinksId__3D5E1FD2",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TvShows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Runtime = table.Column<int>(nullable: true),
                    AverageRuntime = table.Column<int>(nullable: true),
                    Premiered = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ended = table.Column<DateTime>(type: "datetime", nullable: true),
                    OfficialSite = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Updated = table.Column<long>(nullable: true),
                    NetworkId = table.Column<int>(nullable: true),
                    ExternalId = table.Column<int>(nullable: true),
                    ImagesId = table.Column<int>(nullable: true),
                    LinksId = table.Column<int>(nullable: true),
                    RatingsId = table.Column<int>(nullable: true),
                    ScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Externals__TvSho__34C8D9D1",
                        column: x => x.ExternalId,
                        principalTable: "Externals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Ratings__TvShowI__45F365D3",
                        column: x => x.ExternalId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Images__TvShowId__37A5467C",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Links__TvShowId__3A81B327",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TvShows__Network__31EC6D26",
                        column: x => x.NetworkId,
                        principalTable: "Networks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Schedules__TvSho__4316F928",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Networks_CountryId",
                table: "Networks",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Previousepisodes_LinksId",
                table: "Previousepisodes",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_Selves_LinksId",
                table: "Selves",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShows_ExternalId",
                table: "TvShows",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShows_ImagesId",
                table: "TvShows",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShows_LinksId",
                table: "TvShows",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShows_NetworkId",
                table: "TvShows",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_TvShows_ScheduleId",
                table: "TvShows",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WebChannels_CountryId",
                table: "WebChannels",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DvdCountries");

            migrationBuilder.DropTable(
                name: "Previousepisodes");

            migrationBuilder.DropTable(
                name: "Selves");

            migrationBuilder.DropTable(
                name: "TvShows");

            migrationBuilder.DropTable(
                name: "WebChannels");

            migrationBuilder.DropTable(
                name: "Externals");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Networks");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
