using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSetForFollower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follower_Users_FollowerId",
                table: "Follower");

            migrationBuilder.DropForeignKey(
                name: "FK_Follower_Users_FollowingId",
                table: "Follower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follower",
                table: "Follower");

            migrationBuilder.RenameTable(
                name: "Follower",
                newName: "Followers");

            migrationBuilder.RenameIndex(
                name: "IX_Follower_FollowingId",
                table: "Followers",
                newName: "IX_Followers_FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_Follower_FollowerId",
                table: "Followers",
                newName: "IX_Followers_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followers",
                table: "Followers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Users_FollowerId",
                table: "Followers",
                column: "FollowerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Users_FollowingId",
                table: "Followers",
                column: "FollowingId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Users_FollowerId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Users_FollowingId",
                table: "Followers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followers",
                table: "Followers");

            migrationBuilder.RenameTable(
                name: "Followers",
                newName: "Follower");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_FollowingId",
                table: "Follower",
                newName: "IX_Follower_FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_FollowerId",
                table: "Follower",
                newName: "IX_Follower_FollowerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follower",
                table: "Follower",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_Users_FollowerId",
                table: "Follower",
                column: "FollowerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_Users_FollowingId",
                table: "Follower",
                column: "FollowingId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
