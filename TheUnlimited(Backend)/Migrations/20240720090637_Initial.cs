using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheUnlimited_Backend_.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentLevels",
                columns: table => new
                {
                    AgentLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentLevels", x => x.AgentLevelID);
                });

            migrationBuilder.CreateTable(
                name: "AgentStatuses",
                columns: table => new
                {
                    AgentStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentStatuses", x => x.AgentStatusID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommissionStatuses",
                columns: table => new
                {
                    CommissionStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionStatuses", x => x.CommissionStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "EarnedTypes",
                columns: table => new
                {
                    EarnedTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarnedTypes", x => x.EarnedTypeID);
                });

            migrationBuilder.CreateTable(
                name: "HelpCategories",
                columns: table => new
                {
                    HelpCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpCategories", x => x.HelpCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Juices",
                columns: table => new
                {
                    JuiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JuiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JuicePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juices", x => x.JuiceID);
                });

            migrationBuilder.CreateTable(
                name: "MerchLevels",
                columns: table => new
                {
                    MerchLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchLevels", x => x.MerchLevelID);
                });

            migrationBuilder.CreateTable(
                name: "OwnerTypes",
                columns: table => new
                {
                    OwnerTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerTypes", x => x.OwnerTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ParentLevels",
                columns: table => new
                {
                    ParentLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentLevels", x => x.ParentLevelID);
                });

            migrationBuilder.CreateTable(
                name: "PayoutRules",
                columns: table => new
                {
                    PayoutRuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayoutPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutRules", x => x.PayoutRuleID);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanID);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceID);
                });

            migrationBuilder.CreateTable(
                name: "QueryStatuses",
                columns: table => new
                {
                    QueryStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryStatuses", x => x.QueryStatusID);
                });

            migrationBuilder.CreateTable(
                name: "RewardTypes",
                columns: table => new
                {
                    RewardTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardTypes", x => x.RewardTypeID);
                });

            migrationBuilder.CreateTable(
                name: "SalesChannels",
                columns: table => new
                {
                    SalesChannelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesChannels", x => x.SalesChannelID);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestID);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserProfileID);
                });

            migrationBuilder.CreateTable(
                name: "VATs",
                columns: table => new
                {
                    VATID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VATs", x => x.VATID);
                });

            migrationBuilder.CreateTable(
                name: "YearWeeks",
                columns: table => new
                {
                    YearWeekID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearWeeks", x => x.YearWeekID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Helps",
                columns: table => new
                {
                    HelpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HelpCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helps", x => x.HelpID);
                    table.ForeignKey(
                        name: "FK_Helps_HelpCategories_HelpCategoryID",
                        column: x => x.HelpCategoryID,
                        principalTable: "HelpCategories",
                        principalColumn: "HelpCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchCodes",
                columns: table => new
                {
                    MerchCodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchLevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchCodes", x => x.MerchCodeID);
                    table.ForeignKey(
                        name: "FK_MerchCodes_MerchLevels_MerchLevelID",
                        column: x => x.MerchLevelID,
                        principalTable: "MerchLevels",
                        principalColumn: "MerchLevelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerID);
                    table.ForeignKey(
                        name: "FK_Owners_OwnerTypes_OwnerTypeID",
                        column: x => x.OwnerTypeID,
                        principalTable: "OwnerTypes",
                        principalColumn: "OwnerTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    BenefitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanID = table.Column<int>(type: "int", nullable: false),
                    BenefitDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.BenefitID);
                    table.ForeignKey(
                        name: "FK_Benefits_Plans_PlanID",
                        column: x => x.PlanID,
                        principalTable: "Plans",
                        principalColumn: "PlanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPlans",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    PlanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPlans", x => new { x.ContactID, x.PlanID });
                    table.ForeignKey(
                        name: "FK_ContactPlans_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactPlans_Plans_PlanID",
                        column: x => x.PlanID,
                        principalTable: "Plans",
                        principalColumn: "PlanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "TestAccesses",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false),
                    AgentLevelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAccesses", x => new { x.TestID, x.AgentLevelID });
                    table.ForeignKey(
                        name: "FK_TestAccesses_AgentLevels_AgentLevelID",
                        column: x => x.AgentLevelID,
                        principalTable: "AgentLevels",
                        principalColumn: "AgentLevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestAccesses_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    TestQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.TestQuestionID);
                    table.ForeignKey(
                        name: "FK_TestQuestions_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeCode = table.Column<int>(type: "int", nullable: true),
                    OfficeLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeId);
                    table.ForeignKey(
                        name: "FK_Offices_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "OwnerID");
                });

            migrationBuilder.CreateTable(
                name: "CommissionRates",
                columns: table => new
                {
                    CommissionRateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionRates", x => x.CommissionRateID);
                    table.ForeignKey(
                        name: "FK_CommissionRates_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mandates",
                columns: table => new
                {
                    MandateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mandates", x => x.MandateID);
                    table.ForeignKey(
                        name: "FK_Mandates_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mandates_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestAnswers",
                columns: table => new
                {
                    TestAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestQuestionID = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnswers", x => x.TestAnswerID);
                    table.ForeignKey(
                        name: "FK_TestAnswers_TestQuestions_TestQuestionID",
                        column: x => x.TestQuestionID,
                        principalTable: "TestQuestions",
                        principalColumn: "TestQuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestWrongAnswers",
                columns: table => new
                {
                    TestWrongAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestQuestionID = table.Column<int>(type: "int", nullable: false),
                    WrongAnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestWrongAnswers", x => x.TestWrongAnswerID);
                    table.ForeignKey(
                        name: "FK_TestWrongAnswers_TestQuestions_TestQuestionID",
                        column: x => x.TestQuestionID,
                        principalTable: "TestQuestions",
                        principalColumn: "TestQuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentLevelID = table.Column<int>(type: "int", nullable: false),
                    AgentStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgentStatusID = table.Column<int>(type: "int", nullable: false),
                    AgentTerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OfficeCode = table.Column<int>(type: "int", nullable: true),
                    MerchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UplineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UplineMerchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleID = table.Column<int>(type: "int", nullable: true),
                    SalesChannelID = table.Column<int>(type: "int", nullable: false),
                    UplineID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentID);
                    table.ForeignKey(
                        name: "FK_Agents_AgentLevels_AgentLevelID",
                        column: x => x.AgentLevelID,
                        principalTable: "AgentLevels",
                        principalColumn: "AgentLevelID");
                    table.ForeignKey(
                        name: "FK_Agents_AgentStatuses_AgentStatusID",
                        column: x => x.AgentStatusID,
                        principalTable: "AgentStatuses",
                        principalColumn: "AgentStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agents_Agents_UplineID",
                        column: x => x.UplineID,
                        principalTable: "Agents",
                        principalColumn: "AgentID");
                    table.ForeignKey(
                        name: "FK_Agents_Offices_OfficeCode",
                        column: x => x.OfficeCode,
                        principalTable: "Offices",
                        principalColumn: "OfficeId");
                    table.ForeignKey(
                        name: "FK_Agents_SalesChannels_SalesChannelID",
                        column: x => x.SalesChannelID,
                        principalTable: "SalesChannels",
                        principalColumn: "SalesChannelID");
                    table.ForeignKey(
                        name: "FK_Agents_Schedules_ScheduleID",
                        column: x => x.ScheduleID,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleID");
                });

            migrationBuilder.CreateTable(
                name: "OfficeProvinces",
                columns: table => new
                {
                    OfficeCode = table.Column<int>(type: "int", nullable: false),
                    ProvinceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeProvinces", x => new { x.OfficeCode, x.ProvinceID });
                    table.ForeignKey(
                        name: "FK_OfficeProvinces_Offices_OfficeCode",
                        column: x => x.OfficeCode,
                        principalTable: "Offices",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeProvinces_Provinces_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserProfileID = table.Column<int>(type: "int", nullable: false),
                    AgentID = table.Column<int>(type: "int", nullable: true),
                    VerificationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationCodeExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgentID1 = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "AgentID");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Agents_AgentID1",
                        column: x => x.AgentID1,
                        principalTable: "Agents",
                        principalColumn: "AgentID");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserProfiles_UserProfileID",
                        column: x => x.UserProfileID,
                        principalTable: "UserProfiles",
                        principalColumn: "UserProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hierarchies",
                columns: table => new
                {
                    HierarchyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentMerchCode = table.Column<int>(type: "int", nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentLevelID = table.Column<int>(type: "int", nullable: false),
                    TTB = table.Column<double>(type: "float", nullable: false),
                    DialTime = table.Column<double>(type: "float", nullable: false),
                    AgentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchies", x => x.HierarchyID);
                    table.ForeignKey(
                        name: "FK_Hierarchies_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "AgentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hierarchies_ParentLevels_ParentLevelID",
                        column: x => x.ParentLevelID,
                        principalTable: "ParentLevels",
                        principalColumn: "ParentLevelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSales",
                columns: table => new
                {
                    ProductSalesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SalesAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesChannelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSales", x => x.ProductSalesID);
                    table.ForeignKey(
                        name: "FK_ProductSales_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "AgentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSales_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSales_SalesChannels_SalesChannelID",
                        column: x => x.SalesChannelID,
                        principalTable: "SalesChannels",
                        principalColumn: "SalesChannelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    PromotionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentID = table.Column<int>(type: "int", nullable: false),
                    PromotionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PromotionDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.PromotionID);
                    table.ForeignKey(
                        name: "FK_Promotions_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "AgentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    QueryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentID = table.Column<int>(type: "int", nullable: false),
                    QueryText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueryStatusID = table.Column<int>(type: "int", nullable: false),
                    QueryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.QueryID);
                    table.ForeignKey(
                        name: "FK_Queries_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "AgentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Queries_QueryStatuses_QueryStatusID",
                        column: x => x.QueryStatusID,
                        principalTable: "QueryStatuses",
                        principalColumn: "QueryStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    RewardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentID = table.Column<int>(type: "int", nullable: false),
                    RewardTypeID = table.Column<int>(type: "int", nullable: false),
                    RewardDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RewardAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.RewardID);
                    table.ForeignKey(
                        name: "FK_Rewards_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "AgentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rewards_RewardTypes_RewardTypeID",
                        column: x => x.RewardTypeID,
                        principalTable: "RewardTypes",
                        principalColumn: "RewardTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesTargets",
                columns: table => new
                {
                    SalesTargetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentID = table.Column<int>(type: "int", nullable: false),
                    TargetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTargets", x => x.SalesTargetID);
                    table.ForeignKey(
                        name: "FK_SalesTargets_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "AgentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditTrails",
                columns: table => new
                {
                    AuditTrailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogoutTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrails", x => x.AuditTrailID);
                    table.ForeignKey(
                        name: "FK_AuditTrails_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "AgentID");
                    table.ForeignKey(
                        name: "FK_AuditTrails_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    CommissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchCode = table.Column<int>(type: "int", nullable: false),
                    AgentID = table.Column<int>(type: "int", nullable: false),
                    AgentStatusID = table.Column<int>(type: "int", nullable: false),
                    ProductSalesID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Sales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GuaranteedCommission = table.Column<int>(type: "int", nullable: false),
                    Override = table.Column<int>(type: "int", nullable: false),
                    Commissions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalEarnings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionStatusID = table.Column<int>(type: "int", nullable: true),
                    DebiCheckPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsTrainer = table.Column<bool>(type: "bit", nullable: false),
                    IsTrainerOwner = table.Column<bool>(type: "bit", nullable: false),
                    SalesCount = table.Column<int>(type: "int", nullable: false),
                    SalesChannelID = table.Column<int>(type: "int", nullable: true),
                    AgentLevelID = table.Column<int>(type: "int", nullable: true),
                    ProductCategoryID = table.Column<int>(type: "int", nullable: true),
                    EarnedTypeID = table.Column<int>(type: "int", nullable: true),
                    PayoutRuleID = table.Column<int>(type: "int", nullable: true),
                    YearWeekID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.CommissionID);
                    table.ForeignKey(
                        name: "FK_Commissions_AgentLevels_AgentLevelID",
                        column: x => x.AgentLevelID,
                        principalTable: "AgentLevels",
                        principalColumn: "AgentLevelID");
                    table.ForeignKey(
                        name: "FK_Commissions_AgentStatuses_AgentStatusID",
                        column: x => x.AgentStatusID,
                        principalTable: "AgentStatuses",
                        principalColumn: "AgentStatusID");
                    table.ForeignKey(
                        name: "FK_Commissions_Agents_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agents",
                        principalColumn: "AgentID");
                    table.ForeignKey(
                        name: "FK_Commissions_CommissionStatuses_CommissionStatusID",
                        column: x => x.CommissionStatusID,
                        principalTable: "CommissionStatuses",
                        principalColumn: "CommissionStatusID");
                    table.ForeignKey(
                        name: "FK_Commissions_EarnedTypes_EarnedTypeID",
                        column: x => x.EarnedTypeID,
                        principalTable: "EarnedTypes",
                        principalColumn: "EarnedTypeID");
                    table.ForeignKey(
                        name: "FK_Commissions_PayoutRules_PayoutRuleID",
                        column: x => x.PayoutRuleID,
                        principalTable: "PayoutRules",
                        principalColumn: "PayoutRuleID");
                    table.ForeignKey(
                        name: "FK_Commissions_ProductCategories_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryID");
                    table.ForeignKey(
                        name: "FK_Commissions_ProductSales_SalesChannelID",
                        column: x => x.SalesChannelID,
                        principalTable: "ProductSales",
                        principalColumn: "ProductSalesID");
                    table.ForeignKey(
                        name: "FK_Commissions_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Commissions_SalesChannels_SalesChannelID",
                        column: x => x.SalesChannelID,
                        principalTable: "SalesChannels",
                        principalColumn: "SalesChannelID");
                    table.ForeignKey(
                        name: "FK_Commissions_YearWeeks_YearWeekID",
                        column: x => x.YearWeekID,
                        principalTable: "YearWeeks",
                        principalColumn: "YearWeekID");
                });

            migrationBuilder.InsertData(
                table: "AgentLevels",
                columns: new[] { "AgentLevelID", "LevelDescription" },
                values: new object[,]
                {
                    { 1, "Trainee" },
                    { 2, "Trainer" },
                    { 3, "Trainee Owner" },
                    { 4, "Owner" },
                    { 5, "Promoting Owner" },
                    { 6, "Divisional Owner" },
                    { 7, "Vice President" }
                });

            migrationBuilder.InsertData(
                table: "AgentStatuses",
                columns: new[] { "AgentStatusID", "StatusDescription" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "CommissionStatuses",
                columns: new[] { "CommissionStatusID", "Description" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approved" },
                    { 3, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "EarnedTypes",
                columns: new[] { "EarnedTypeID", "Description" },
                values: new object[,]
                {
                    { 1, "Commissions" },
                    { 2, "Overrides" },
                    { 3, "Guaranteed Commission" },
                    { 4, "Attendance Bonus" },
                    { 5, "Performance Bonus" }
                });

            migrationBuilder.InsertData(
                table: "OwnerTypes",
                columns: new[] { "OwnerTypeID", "TypeDescription" },
                values: new object[,]
                {
                    { 1, "Promotional owner" },
                    { 2, "Trainer Owner" },
                    { 3, "Divisional Owner" }
                });

            migrationBuilder.InsertData(
                table: "ParentLevels",
                columns: new[] { "ParentLevelID", "Description" },
                values: new object[,]
                {
                    { 1, "Trainer" },
                    { 2, "Trainer Owner" },
                    { 3, "Promoting Owner" },
                    { 4, "Divisional Owner" },
                    { 5, "Vice President" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Motor" },
                    { 2, "Non-Motor" },
                    { 3, "Persal" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceID", "ProvinceName" },
                values: new object[,]
                {
                    { 1, "NW" },
                    { 2, "NC" },
                    { 3, "FS" },
                    { 4, "WC" },
                    { 5, "EC" },
                    { 6, "KZN" },
                    { 7, "MP" },
                    { 8, "GP" },
                    { 9, "L" }
                });

            migrationBuilder.InsertData(
                table: "QueryStatuses",
                columns: new[] { "QueryStatusID", "StatusName" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "RewardTypes",
                columns: new[] { "RewardTypeID", "TypeDescription" },
                values: new object[,]
                {
                    { 1, "Bonus" },
                    { 2, "Promotion" }
                });

            migrationBuilder.InsertData(
                table: "SalesChannels",
                columns: new[] { "SalesChannelID", "ChannelDescription" },
                values: new object[,]
                {
                    { 1, "Telesale" },
                    { 2, "Face-to-Face" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleID", "Description" },
                values: new object[,]
                {
                    { 1, "Weekly" },
                    { 2, "Monthly" }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "TestID", "TestName" },
                values: new object[,]
                {
                    { 1, "Sales Manual Test" },
                    { 2, "Trainer Manual Test" },
                    { 3, "Owner's Manual Test" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "UserProfileID", "ProfileDescription" },
                values: new object[,]
                {
                    { 1, "System Administrator" },
                    { 2, "Payroll Manager" },
                    { 3, "User" },
                    { 4, "Super User" },
                    { 5, "Owner" },
                    { 6, "Agent User" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerID", "OwnerName", "OwnerTypeID" },
                values: new object[,]
                {
                    { 1, "Promotional owner", 1 },
                    { 2, "Trainer Owner", 2 },
                    { 3, "Divisional Owner", 3 }
                });

            migrationBuilder.InsertData(
                table: "TestAccesses",
                columns: new[] { "AgentLevelID", "TestID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "TestQuestions",
                columns: new[] { "TestQuestionID", "QuestionText", "TestID" },
                values: new object[,]
                {
                    { 1, "What is the guaranteed commission for new agents per working day?", 1 },
                    { 2, "What is the minimum dial time required for a full day's commission?", 1 },
                    { 3, "How much is paid for dial time between 120 to 149 minutes?", 1 },
                    { 4, "What is the commission rate for 1-23 adjusted pieces below 40% Debi Check?", 1 },
                    { 5, "What is the default Success Rate (SR) for new agents in the Motor category?", 1 },
                    { 6, "What is the commission for 24+ adjusted pieces above 40% Debi Check?", 1 },
                    { 7, "How many days are included in the first pay cycle of 2023?", 1 },
                    { 8, "What is the commission rate for 24+ adjusted pieces below 40% Debi Check?", 1 },
                    { 9, "What is the qualifying criteria for a Trainer override?", 1 },
                    { 10, "How many personal adjusted pieces are required for a Trainee Owner override?", 1 },
                    { 11, "What is the guaranteed commission for new agents per working day in the Persal category?", 2 },
                    { 12, "What is the commission rate for 1-16 adjusted pieces in Persal?", 2 },
                    { 13, "What is the default SR for new agents in Persal?", 2 },
                    { 14, "What is the qualifying criteria for a Trainer override in Persal?", 2 },
                    { 15, "What is the commission for 17+ adjusted pieces in the Persal Gap category?", 2 },
                    { 16, "How many days are included in the second pay cycle of 2023?", 2 },
                    { 17, "What is the commission rate for 1-16 adjusted pieces in Persal STD Upgrade?", 2 },
                    { 18, "How many personal adjusted pieces are required for a Trainee Owner override in Persal?", 2 },
                    { 19, "What is the commission rate for 17+ adjusted pieces in Persal Code GAP Upgrade?", 2 },
                    { 20, "What is the dial time required for a half day's commission?", 2 },
                    { 21, "What is the guaranteed commission for new agents per working day in the Debit Order category?", 3 },
                    { 22, "What is the commission rate for 1-19 adjusted pieces below 40% Debi Check in Debit Order?", 3 },
                    { 23, "What is the default SR for new agents in Debit Order?", 3 },
                    { 24, "What is the qualifying criteria for a Trainer override in Debit Order?", 3 },
                    { 25, "What is the commission for 20+ adjusted pieces above 40% Debi Check in Debit Order?", 3 },
                    { 26, "How many days are included in the third pay cycle of 2023?", 3 },
                    { 27, "What is the commission rate for 1-19 adjusted pieces above 40% Debi Check in Debit Order?", 3 },
                    { 28, "How many personal adjusted pieces are required for a Trainee Owner override in Debit Order?", 3 },
                    { 29, "What is the commission rate for 20+ adjusted pieces below 40% Debi Check in Debit Order?", 3 },
                    { 30, "What is the dial time required for a full day's commission in Debit Order?", 3 }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "OfficeId", "OfficeCode", "OfficeLocation", "OwnerID" },
                values: new object[,]
                {
                    { 1, 1, "NW", 1 },
                    { 2, 2, "L", 2 },
                    { 3, 3, "GP", 3 }
                });

            migrationBuilder.InsertData(
                table: "TestAnswers",
                columns: new[] { "TestAnswerID", "AnswerText", "IsCorrect", "TestQuestionID" },
                values: new object[,]
                {
                    { 1, "R200", true, 1 },
                    { 2, "150 minutes", true, 2 },
                    { 3, "R100", true, 3 },
                    { 4, "R300", true, 4 },
                    { 5, "60%", true, 5 },
                    { 6, "R450", true, 6 },
                    { 7, "13 days", true, 7 },
                    { 8, "R400", true, 8 },
                    { 9, "19 personal adjusted pieces and 50% SR", true, 9 },
                    { 10, "19", true, 10 },
                    { 11, "R200", true, 11 },
                    { 12, "R350", true, 12 },
                    { 13, "85%", true, 13 },
                    { 14, "27 personal adjusted pieces and 50% SR", true, 14 },
                    { 15, "R575", true, 15 },
                    { 16, "20 days", true, 16 },
                    { 17, "R350", true, 17 },
                    { 18, "27", true, 18 },
                    { 19, "R550", true, 19 },
                    { 20, "120 to 149 minutes", true, 20 },
                    { 21, "R200", true, 21 },
                    { 22, "R300", true, 22 },
                    { 23, "50%", true, 23 },
                    { 24, "16 personal adjusted pieces and 50% SR", true, 24 },
                    { 25, "R450", true, 25 },
                    { 26, "20 days", true, 26 },
                    { 27, "R350", true, 27 },
                    { 28, "16", true, 28 },
                    { 29, "R400", true, 29 },
                    { 30, "150 minutes", true, 30 }
                });

            migrationBuilder.InsertData(
                table: "TestWrongAnswers",
                columns: new[] { "TestWrongAnswerID", "TestQuestionID", "WrongAnswerText" },
                values: new object[,]
                {
                    { 1, 1, "R150" },
                    { 2, 1, "R250" },
                    { 3, 1, "R300" },
                    { 4, 2, "120 minutes" },
                    { 5, 2, "100 minutes" },
                    { 6, 2, "200 minutes" },
                    { 7, 3, "R150" },
                    { 8, 3, "R50" },
                    { 9, 3, "R200" },
                    { 10, 4, "R350" },
                    { 11, 4, "R400" },
                    { 12, 4, "R250" },
                    { 13, 5, "50%" },
                    { 14, 5, "70%" },
                    { 15, 5, "80%" },
                    { 16, 6, "R400" },
                    { 17, 6, "R500" },
                    { 18, 6, "R350" },
                    { 19, 7, "20 days" },
                    { 20, 7, "15 days" },
                    { 21, 7, "10 days" },
                    { 22, 8, "R350" },
                    { 23, 8, "R450" },
                    { 24, 8, "R300" },
                    { 25, 9, "20 personal adjusted pieces and 60% SR" },
                    { 26, 9, "18 personal adjusted pieces and 55% SR" },
                    { 27, 9, "25 personal adjusted pieces and 70% SR" },
                    { 28, 10, "20" },
                    { 29, 10, "25" },
                    { 30, 10, "15" },
                    { 31, 11, "R250" },
                    { 32, 11, "R150" },
                    { 33, 11, "R300" },
                    { 34, 12, "R300" },
                    { 35, 12, "R400" },
                    { 36, 12, "R250" },
                    { 37, 13, "75%" },
                    { 38, 13, "95%" },
                    { 39, 13, "90%" },
                    { 40, 14, "25 personal adjusted pieces and 60% SR" },
                    { 41, 14, "20 personal adjusted pieces and 55% SR" },
                    { 42, 14, "30 personal adjusted pieces and 70% SR" },
                    { 43, 15, "R500" },
                    { 44, 15, "R600" },
                    { 45, 15, "R550" },
                    { 46, 16, "15 days" },
                    { 47, 16, "25 days" },
                    { 48, 16, "10 days" },
                    { 49, 17, "R300" },
                    { 50, 17, "R400" },
                    { 51, 17, "R200" },
                    { 52, 18, "20" },
                    { 53, 18, "25" },
                    { 54, 18, "15" },
                    { 55, 19, "R500" },
                    { 56, 19, "R600" },
                    { 57, 19, "R450" },
                    { 58, 20, "100 to 119 minutes" },
                    { 59, 20, "150 to 179 minutes" },
                    { 60, 20, "90 to 119 minutes" },
                    { 61, 21, "R150" },
                    { 62, 21, "R250" },
                    { 63, 21, "R300" },
                    { 64, 22, "R350" },
                    { 65, 22, "R250" },
                    { 66, 22, "R400" },
                    { 67, 23, "60%" },
                    { 68, 23, "40%" },
                    { 69, 23, "70%" },
                    { 70, 24, "15 personal adjusted pieces and 60% SR" },
                    { 71, 24, "17 personal adjusted pieces and 55% SR" },
                    { 72, 24, "18 personal adjusted pieces and 70% SR" },
                    { 73, 25, "R400" },
                    { 74, 25, "R500" },
                    { 75, 25, "R350" },
                    { 76, 26, "15 days" },
                    { 77, 26, "25 days" },
                    { 78, 26, "10 days" },
                    { 79, 27, "R300" },
                    { 80, 27, "R400" },
                    { 81, 27, "R200" },
                    { 82, 28, "15" },
                    { 83, 28, "20" },
                    { 84, 28, "25" },
                    { 85, 29, "R350" },
                    { 86, 29, "R450" },
                    { 87, 29, "R300" },
                    { 88, 30, "100 minutes" },
                    { 89, 30, "200 minutes" },
                    { 90, 30, "120 minutes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AgentLevelID",
                table: "Agents",
                column: "AgentLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_AgentStatusID",
                table: "Agents",
                column: "AgentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_OfficeCode",
                table: "Agents",
                column: "OfficeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_SalesChannelID",
                table: "Agents",
                column: "SalesChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ScheduleID",
                table: "Agents",
                column: "ScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UplineID",
                table: "Agents",
                column: "UplineID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AgentID",
                table: "AspNetUsers",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AgentID1",
                table: "AspNetUsers",
                column: "AgentID1",
                unique: true,
                filter: "[AgentID1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserProfileID",
                table: "AspNetUsers",
                column: "UserProfileID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrails_AgentID",
                table: "AuditTrails",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrails_UserID",
                table: "AuditTrails",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_PlanID",
                table: "Benefits",
                column: "PlanID");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionRates_ProductID",
                table: "CommissionRates",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_AgentID",
                table: "Commissions",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_AgentLevelID",
                table: "Commissions",
                column: "AgentLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_AgentStatusID",
                table: "Commissions",
                column: "AgentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_CommissionStatusID",
                table: "Commissions",
                column: "CommissionStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_EarnedTypeID",
                table: "Commissions",
                column: "EarnedTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_PayoutRuleID",
                table: "Commissions",
                column: "PayoutRuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_ProductCategoryID",
                table: "Commissions",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_ProductID",
                table: "Commissions",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_SalesChannelID",
                table: "Commissions",
                column: "SalesChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_YearWeekID",
                table: "Commissions",
                column: "YearWeekID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPlans_PlanID",
                table: "ContactPlans",
                column: "PlanID");

            migrationBuilder.CreateIndex(
                name: "IX_Helps_HelpCategoryID",
                table: "Helps",
                column: "HelpCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchies_AgentID",
                table: "Hierarchies",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Hierarchies_ParentLevelID",
                table: "Hierarchies",
                column: "ParentLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Mandates_ContactID",
                table: "Mandates",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Mandates_ProductID",
                table: "Mandates",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_MerchCodes_MerchLevelID",
                table: "MerchCodes",
                column: "MerchLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeProvinces_ProvinceID",
                table: "OfficeProvinces",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_OwnerID",
                table: "Offices",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_OwnerTypeID",
                table: "Owners",
                column: "OwnerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryID",
                table: "Products",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_AgentID",
                table: "ProductSales",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_ProductID",
                table: "ProductSales",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_SalesChannelID",
                table: "ProductSales",
                column: "SalesChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_AgentID",
                table: "Promotions",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_AgentID",
                table: "Queries",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_QueryStatusID",
                table: "Queries",
                column: "QueryStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_AgentID",
                table: "Rewards",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_RewardTypeID",
                table: "Rewards",
                column: "RewardTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesTargets_AgentID",
                table: "SalesTargets",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_TestAccesses_AgentLevelID",
                table: "TestAccesses",
                column: "AgentLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswers_TestQuestionID",
                table: "TestAnswers",
                column: "TestQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_TestID",
                table: "TestQuestions",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_TestWrongAnswers_TestQuestionID",
                table: "TestWrongAnswers",
                column: "TestQuestionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditTrails");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "CommissionRates");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "ContactPlans");

            migrationBuilder.DropTable(
                name: "Helps");

            migrationBuilder.DropTable(
                name: "Hierarchies");

            migrationBuilder.DropTable(
                name: "Juices");

            migrationBuilder.DropTable(
                name: "Mandates");

            migrationBuilder.DropTable(
                name: "MerchCodes");

            migrationBuilder.DropTable(
                name: "OfficeProvinces");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Queries");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "SalesTargets");

            migrationBuilder.DropTable(
                name: "TestAccesses");

            migrationBuilder.DropTable(
                name: "TestAnswers");

            migrationBuilder.DropTable(
                name: "TestWrongAnswers");

            migrationBuilder.DropTable(
                name: "VATs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CommissionStatuses");

            migrationBuilder.DropTable(
                name: "EarnedTypes");

            migrationBuilder.DropTable(
                name: "PayoutRules");

            migrationBuilder.DropTable(
                name: "ProductSales");

            migrationBuilder.DropTable(
                name: "YearWeeks");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "HelpCategories");

            migrationBuilder.DropTable(
                name: "ParentLevels");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "MerchLevels");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "QueryStatuses");

            migrationBuilder.DropTable(
                name: "RewardTypes");

            migrationBuilder.DropTable(
                name: "TestQuestions");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "AgentLevels");

            migrationBuilder.DropTable(
                name: "AgentStatuses");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "SalesChannels");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "OwnerTypes");
        }
    }
}
