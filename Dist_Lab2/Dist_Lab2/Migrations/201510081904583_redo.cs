namespace Dist_Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Receiver_MessageId", "dbo.Messages");
            DropForeignKey("dbo.AspNetUsers", "Message_MessageId", "dbo.Messages");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Receiver_MessageId" });
            DropIndex("dbo.AspNetUsers", new[] { "Message_MessageId" });
            DropColumn("dbo.AspNetUsers", "Receiver_MessageId");
            DropColumn("dbo.AspNetUsers", "Message_MessageId");
            DropTable("dbo.Messages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        Body = c.String(nullable: false),
                        TimeSent = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Status = c.String(nullable: false),
                        Sender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId);
            
            AddColumn("dbo.AspNetUsers", "Message_MessageId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Receiver_MessageId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Message_MessageId");
            CreateIndex("dbo.AspNetUsers", "Receiver_MessageId");
            CreateIndex("dbo.Messages", "Sender_Id");
            AddForeignKey("dbo.Messages", "Sender_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Message_MessageId", "dbo.Messages", "MessageId");
            AddForeignKey("dbo.AspNetUsers", "Receiver_MessageId", "dbo.Messages", "MessageId");
        }
    }
}
