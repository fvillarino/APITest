using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APITest.Models
{
    public partial class DB_CLOUDPLAYOUTContext : DbContext
    {
        public DB_CLOUDPLAYOUTContext()
        {
        }

        public DB_CLOUDPLAYOUTContext(DbContextOptions<DB_CLOUDPLAYOUTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CpoAppendRequest> CpoAppendRequest { get; set; }
        public virtual DbSet<CpoAppendStatus> CpoAppendStatus { get; set; }
        public virtual DbSet<CpoCueTriggerType> CpoCueTriggerType { get; set; }
        public virtual DbSet<CpoEventType> CpoEventType { get; set; }
        public virtual DbSet<CpoFeed> CpoFeed { get; set; }
        public virtual DbSet<CpoLogProcessType> CpoLogProcessType { get; set; }
        public virtual DbSet<CpoProcess> CpoProcess { get; set; }
        public virtual DbSet<CpoRequest> CpoRequest { get; set; }
        public virtual DbSet<CpoRequestRestore> CpoRequestRestore { get; set; }
        public virtual DbSet<CpoRequestStatus> CpoRequestStatus { get; set; }
        public virtual DbSet<CpoRequestStatusHistory> CpoRequestStatusHistory { get; set; }
        public virtual DbSet<CpoRequestSubtitle> CpoRequestSubtitle { get; set; }
        public virtual DbSet<CpoRequestTranscode> CpoRequestTranscode { get; set; }
        public virtual DbSet<CpoRequestType> CpoRequestType { get; set; }
        public virtual DbSet<CpoSubtitleLanguage> CpoSubtitleLanguage { get; set; }
        public virtual DbSet<CpoTranscoder> CpoTranscoder { get; set; }
        public virtual DbSet<CpoTranscoderInstance> CpoTranscoderInstance { get; set; }
        public virtual DbSet<CpoVideoFormat> CpoVideoFormat { get; set; }
        public virtual DbSet<CpoVideoType> CpoVideoType { get; set; }

        // Unable to generate entity type for table 'dbo.CPO_FeedSubtitleLanguage'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CPO_CueTrigger'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CPO_FeedRequest'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CPO_LogProcess'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=10.161.237.206;Initial Catalog=DB_CLOUDPLAYOUT;Persist Security Info=True;User ID=db_cpo; Password=db_cpo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<CpoAppendRequest>(entity =>
            {
                entity.HasKey(e => new { e.Idfeed, e.AppendRequestDate, e.AppendRequestVersion });

                entity.ToTable("CPO_AppendRequest");

                entity.Property(e => e.Idfeed).HasColumnName("IDFeed");

                entity.Property(e => e.AppendRequestDate).HasColumnType("date");

                entity.Property(e => e.AppendRequestLogFileName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AppendRequestResponse)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.IdappendStatus).HasColumnName("IDAppendStatus");

                entity.Property(e => e.StatusAppendRequestDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdappendStatusNavigation)
                    .WithMany(p => p.CpoAppendRequest)
                    .HasForeignKey(d => d.IdappendStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPO_AppendRequest_CPO_AppendStatus");

                entity.HasOne(d => d.IdfeedNavigation)
                    .WithMany(p => p.CpoAppendRequest)
                    .HasForeignKey(d => d.Idfeed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPO_AppendRequest_CPO_Feed");
            });

            modelBuilder.Entity<CpoAppendStatus>(entity =>
            {
                entity.HasKey(e => e.IdappendStatus);

                entity.ToTable("CPO_AppendStatus");

                entity.Property(e => e.IdappendStatus)
                    .HasColumnName("IDAppendStatus")
                    .ValueGeneratedNever();

                entity.Property(e => e.AppendStatusDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AppendStatusFriendlyName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AppendStatusName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CpoCueTriggerType>(entity =>
            {
                entity.HasKey(e => e.IdcueTriggerType);

                entity.ToTable("CPO_CueTriggerType");

                entity.Property(e => e.IdcueTriggerType)
                    .HasColumnName("IDCueTriggerType")
                    .ValueGeneratedNever();

                entity.Property(e => e.CueTriggerTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CpoEventType>(entity =>
            {
                entity.HasKey(e => e.IdeventType);

                entity.ToTable("CPO_EventType");

                entity.Property(e => e.IdeventType)
                    .HasColumnName("IDEventType")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventTypeFriendlyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CpoFeed>(entity =>
            {
                entity.HasKey(e => e.Idfeed);

                entity.ToTable("CPO_Feed");

                entity.Property(e => e.Idfeed).HasColumnName("IDFeed");

                entity.Property(e => e.Divacategory)
                    .HasColumnName("DIVACategory")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedExternalId)
                    .HasColumnName("FeedExternalID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedInetsatId).HasColumnName("FeedInetsatID");

                entity.Property(e => e.FeedLogName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedOriginalLanguage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedRegion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedRepositoryLog)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FeedRgxLogName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdvideoFormat).HasColumnName("IDVideoFormat");
            });

            modelBuilder.Entity<CpoLogProcessType>(entity =>
            {
                entity.HasKey(e => e.IdlogProcessType);

                entity.ToTable("CPO_LogProcessType");

                entity.Property(e => e.IdlogProcessType)
                    .HasColumnName("IDLogProcessType")
                    .ValueGeneratedNever();

                entity.Property(e => e.LogProcessTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CpoProcess>(entity =>
            {
                entity.HasKey(e => e.ProcessName)
                    .HasName("PK_CPO_Process_1");

                entity.ToTable("CPO_Process");

                entity.Property(e => e.ProcessName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProcessFirstStart)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProcessStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CpoRequest>(entity =>
            {
                entity.HasKey(e => e.Idrequest);

                entity.ToTable("CPO_Request");

                entity.HasIndex(e => e.RequestMaterialId)
                    .HasName("IX_CPO_Request");

                entity.HasIndex(e => e.RequestRequiredDate);

                entity.HasIndex(e => e.RequestStatusDate)
                    .HasName("IX_CPO_Request_RequestDateTime");

                entity.Property(e => e.Idrequest).HasColumnName("IDRequest");

                entity.Property(e => e.IdeventType).HasColumnName("IDEventType");

                entity.Property(e => e.IdrequestStatus).HasColumnName("IDRequestStatus");

                entity.Property(e => e.IdrequestType).HasColumnName("IDRequestType");

                entity.Property(e => e.RequestComment)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RequestLongFileId)
                    .IsRequired()
                    .HasColumnName("RequestLongFileID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestMaterialId)
                    .IsRequired()
                    .HasColumnName("RequestMaterialID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestRequiredDate).HasColumnType("datetime");

                entity.Property(e => e.RequestStatusDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RequestUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdeventTypeNavigation)
                    .WithMany(p => p.CpoRequest)
                    .HasForeignKey(d => d.IdeventType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPO_Request_CPO_EventType");

                entity.HasOne(d => d.IdrequestStatusNavigation)
                    .WithMany(p => p.CpoRequest)
                    .HasForeignKey(d => d.IdrequestStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPO_Request_CPO_RequestStatus");

                entity.HasOne(d => d.IdrequestTypeNavigation)
                    .WithMany(p => p.CpoRequest)
                    .HasForeignKey(d => d.IdrequestType)
                    .HasConstraintName("FK_CPO_Request_CPO_RequestType");
            });

            modelBuilder.Entity<CpoRequestRestore>(entity =>
            {
                entity.HasKey(e => e.Idrequest);

                entity.ToTable("CPO_RequestRestore");

                entity.Property(e => e.Idrequest)
                    .HasColumnName("IDRequest")
                    .ValueGeneratedNever();

                entity.Property(e => e.Divaidrequest).HasColumnName("DIVAIDRequest");

                entity.Property(e => e.Divapriority).HasColumnName("DIVAPriority");

                entity.Property(e => e.DivarestoreFileName)
                    .HasColumnName("DIVARestoreFileName")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdrequestNavigation)
                    .WithOne(p => p.CpoRequestRestore)
                    .HasForeignKey<CpoRequestRestore>(d => d.Idrequest)
                    .HasConstraintName("FK_CPO_RequestRestore_CPO_Request");
            });

            modelBuilder.Entity<CpoRequestStatus>(entity =>
            {
                entity.HasKey(e => e.IdrequestStatus);

                entity.ToTable("CPO_RequestStatus");

                entity.Property(e => e.IdrequestStatus)
                    .HasColumnName("IDRequestStatus")
                    .ValueGeneratedNever();

                entity.Property(e => e.RequestStatusDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequestStatusName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CpoRequestStatusHistory>(entity =>
            {
                entity.HasKey(e => e.IdrequestStatusHistory);

                entity.ToTable("CPO_RequestStatusHistory");

                entity.HasIndex(e => e.Idrequest)
                    .HasName("IX_CPO_RequestStatusHistory");

                entity.HasIndex(e => e.IdrequestStatus)
                    .HasName("IX_CPO_RequestStatusHistory_1");

                entity.HasIndex(e => e.RequestStatusDate)
                    .HasName("IX_CPO_RequestStatusHistory_2");

                entity.Property(e => e.IdrequestStatusHistory).HasColumnName("IDRequestStatusHistory");

                entity.Property(e => e.Idrequest).HasColumnName("IDRequest");

                entity.Property(e => e.IdrequestStatus).HasColumnName("IDRequestStatus");

                entity.Property(e => e.RequestStatusDate).HasColumnType("datetime");

                entity.Property(e => e.RequestStatusHistoryComment)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RequestUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdrequestNavigation)
                    .WithMany(p => p.CpoRequestStatusHistory)
                    .HasForeignKey(d => d.Idrequest)
                    .HasConstraintName("FK_CPO_RequestStatusHistory_CPO_Request");

                entity.HasOne(d => d.IdrequestStatusNavigation)
                    .WithMany(p => p.CpoRequestStatusHistory)
                    .HasForeignKey(d => d.IdrequestStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPO_RequestStatusHistory_CPO_RequestStatus");
            });

            modelBuilder.Entity<CpoRequestSubtitle>(entity =>
            {
                entity.HasKey(e => e.Idrequest);

                entity.ToTable("CPO_RequestSubtitle");

                entity.Property(e => e.Idrequest)
                    .HasColumnName("IDRequest")
                    .ValueGeneratedNever();

                entity.Property(e => e.RequestLanguage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubtitleCid)
                    .HasColumnName("SubtitleCID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubtitleFileName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubtitleLanguage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubtitleTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdrequestNavigation)
                    .WithOne(p => p.CpoRequestSubtitle)
                    .HasForeignKey<CpoRequestSubtitle>(d => d.Idrequest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CPO_RequestSubtitle_CPO_Request");
            });

            modelBuilder.Entity<CpoRequestTranscode>(entity =>
            {
                entity.HasKey(e => e.Idrequest);

                entity.ToTable("CPO_RequestTranscode");

                entity.Property(e => e.Idrequest)
                    .HasColumnName("IDRequest")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClosedCaption).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdtranscoderInstance).HasColumnName("IDTranscoderInstance");

                entity.Property(e => e.IdvideoType).HasColumnName("IDVideoType");

                entity.Property(e => e.IsCropping).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaterialType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RequestAudioShuffling)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequestTranscodeFileNameIn)
                    .HasColumnName("RequestTranscodeFileNameIN")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequestTranscodeFileNameOut)
                    .HasColumnName("RequestTranscodeFileNameOUT")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TimecodeIn)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TranscodeIdrequest)
                    .HasColumnName("TranscodeIDRequest")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdrequestNavigation)
                    .WithOne(p => p.CpoRequestTranscode)
                    .HasForeignKey<CpoRequestTranscode>(d => d.Idrequest)
                    .HasConstraintName("FK_CPO_RequestTranscode_CPO_Request1");

                entity.HasOne(d => d.IdtranscoderInstanceNavigation)
                    .WithMany(p => p.CpoRequestTranscode)
                    .HasForeignKey(d => d.IdtranscoderInstance)
                    .HasConstraintName("FK_CPO_RequestTranscode_CPO_TranscoderInstance");

                entity.HasOne(d => d.IdvideoTypeNavigation)
                    .WithMany(p => p.CpoRequestTranscode)
                    .HasForeignKey(d => d.IdvideoType)
                    .HasConstraintName("FK_CPO_RequestTranscode_CPO_VideoType");
            });

            modelBuilder.Entity<CpoRequestType>(entity =>
            {
                entity.HasKey(e => e.IdrequestType);

                entity.ToTable("CPO_RequestType");

                entity.Property(e => e.IdrequestType)
                    .HasColumnName("IDRequestType")
                    .ValueGeneratedNever();

                entity.Property(e => e.RequestTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CpoSubtitleLanguage>(entity =>
            {
                entity.HasKey(e => e.IdsubtitleLanguage);

                entity.ToTable("CPO_SubtitleLanguage");

                entity.Property(e => e.IdsubtitleLanguage)
                    .HasColumnName("IDSubtitleLanguage")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<CpoTranscoder>(entity =>
            {
                entity.HasKey(e => e.Idtranscoder)
                    .HasName("PK_CPO_Transcoder_1");

                entity.ToTable("CPO_Transcoder");

                entity.Property(e => e.Idtranscoder)
                    .HasColumnName("IDTranscoder")
                    .ValueGeneratedNever();

                entity.Property(e => e.TranscoderName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CpoTranscoderInstance>(entity =>
            {
                entity.HasKey(e => e.IdtranscoderInstance)
                    .HasName("PK_CPO_Transcoder");

                entity.ToTable("CPO_TranscoderInstance");

                entity.Property(e => e.IdtranscoderInstance)
                    .HasColumnName("IDTranscoderInstance")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idtranscoder).HasColumnName("IDTranscoder");

                entity.Property(e => e.TranscoderInstanceServerName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdtranscoderNavigation)
                    .WithMany(p => p.CpoTranscoderInstance)
                    .HasForeignKey(d => d.Idtranscoder)
                    .HasConstraintName("FK_CPO_TranscoderInstance_CPO_Transcoder");
            });

            modelBuilder.Entity<CpoVideoFormat>(entity =>
            {
                entity.HasKey(e => e.IdvideoFormat);

                entity.ToTable("CPO_VideoFormat");

                entity.Property(e => e.IdvideoFormat)
                    .HasColumnName("IDVideoFormat")
                    .ValueGeneratedNever();

                entity.Property(e => e.VideoFormatAspectRatio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VideoFormatDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.VideoFormatFileExtension)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CpoVideoType>(entity =>
            {
                entity.HasKey(e => e.IdvideoType);

                entity.ToTable("CPO_VideoType");

                entity.Property(e => e.IdvideoType)
                    .HasColumnName("IDVideoType")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdvideoFormat).HasColumnName("IDVideoFormat");

                entity.Property(e => e.VideoTypeDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VideoTypeKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdvideoFormatNavigation)
                    .WithMany(p => p.CpoVideoType)
                    .HasForeignKey(d => d.IdvideoFormat)
                    .HasConstraintName("FK_CPO_VideoType_CPO_VideoFormat");
            });
        }
    }
}
