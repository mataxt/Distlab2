namespace Dist_Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .Index(t => t.Sender_Id);
            
            AddColumn("dbo.AspNetUsers", "Receiver_MessageId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Message_MessageId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Receiver_MessageId");
            CreateIndex("dbo.AspNetUsers", "Message_MessageId");
            AddForeignKey("dbo.AspNetUsers", "Receiver_MessageId", "dbo.Messages", "MessageId");
            AddForeignKey("dbo.AspNetUsers", "Message_MessageId", "dbo.Messages", "MessageId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Message_MessageId", "dbo.Messages");
            DropForeignKey("dbo.AspNetUsers", "Receiver_MessageId", "dbo.Messages");
            DropIndex("dbo.AspNetUsers", new[] { "Message_MessageId" });
            DropIndex("dbo.AspNetUsers", new[] { "Receiver_MessageId" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropColumn("dbo.AspNetUsers", "Message_MessageId");
            DropColumn("dbo.AspNetUsers", "Receiver_MessageId");
            DropTable("dbo.Messages");
        }
    }
}
