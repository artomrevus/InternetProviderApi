using InternetProvider.Abstraction.Entities;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Data;

public class InternetProviderContext(DbContextOptions<InternetProviderContext> options) : DbContext(options)
{
    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientStatus> ClientStatuses { get; set; }

    public virtual DbSet<Connection> Connections { get; set; }

    public virtual DbSet<ConnectionEquipment> ConnectionEquipments { get; set; }

    public virtual DbSet<ConnectionTariff> ConnectionTariffs { get; set; }

    public virtual DbSet<ConnectionsReport> ConnectionsReports { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }

    public virtual DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

    public virtual DbSet<EmployeesReport> EmployeesReports { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<EquipmentReport> EquipmentReports { get; set; }

    public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }

    public virtual DbSet<House> Houses { get; set; }

    public virtual DbSet<InternetConnectionRequest> InternetConnectionRequests { get; set; }

    public virtual DbSet<InternetConnectionRequestStatus> InternetConnectionRequestStatuses { get; set; }

    public virtual DbSet<InternetTariff> InternetTariffs { get; set; }

    public virtual DbSet<InternetTariffStatus> InternetTariffStatuses { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationType> LocationTypes { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<OfficeEquipment> OfficeEquipments { get; set; }

    public virtual DbSet<Street> Streets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__031491A82FEEEE5D");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__BF21A424B23CB230");

            entity.ToTable("Client");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Client__A1936A6BA1C1D8C0").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Client__AB6E6164CB8757C8").IsUnique();

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ClientStatusId).HasColumnName("client_status_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.ClientStatus).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ClientStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_client_status");

            entity.HasOne(d => d.Location).WithMany(p => p.Clients)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_location");
        });

        modelBuilder.Entity<ClientStatus>(entity =>
        {
            entity.HasKey(e => e.ClientStatusId).HasName("PK__ClientSt__B82E681503D75972");

            entity.ToTable("ClientStatus");

            entity.Property(e => e.ClientStatusId)
                .ValueGeneratedNever()
                .HasColumnName("client_status_id");
            entity.Property(e => e.ClientStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("client_status");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Connection>(entity =>
        {
            entity.HasKey(e => e.ConnectionId).HasName("PK__Connecti__E4AA4DD0066B8AC9");

            entity.ToTable("Connection_", tb =>
                {
                    tb.HasTrigger("ConnectionInsertTrigger");
                    tb.HasTrigger("ConnectionUpdateTrigger");
                });

            entity.HasIndex(e => e.ConnectionDate, "Connection__connection_date_IDX");

            entity.HasIndex(e => e.InternetConnectionRequestId, "IX_Connection_InternetConnectionRequestId");

            entity.HasIndex(e => e.InternetConnectionRequestId, "UQ__Connecti__AB3061E48A55B137").IsUnique();

            entity.Property(e => e.ConnectionId).HasColumnName("connection_id");
            entity.Property(e => e.ConnectionDate).HasColumnName("connection_date");
            entity.Property(e => e.ConnectionTariffId).HasColumnName("connection_tariff_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.InternetConnectionRequestId).HasColumnName("internet_connection_request_id");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("total_price");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.ConnectionTariff).WithMany(p => p.Connections)
                .HasForeignKey(d => d.ConnectionTariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_connection_tariff");

            entity.HasOne(d => d.Employee).WithMany(p => p.Connections)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee");

            entity.HasOne(d => d.InternetConnectionRequest).WithOne(p => p.Connection)
                .HasForeignKey<Connection>(d => d.InternetConnectionRequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_internet_connection_request");
        });

        modelBuilder.Entity<ConnectionEquipment>(entity =>
        {
            entity.HasKey(e => e.ConnectionEquipmentId).HasName("PK__Connecti__F31B608BE8AC5CC2");

            entity.ToTable("ConnectionEquipment", tb => tb.HasTrigger("ConnectionEquipmentTrigger"));

            entity.HasIndex(e => e.ConnectionId, "IX_ConnectionEquipment_Connection_Id");

            entity.HasIndex(e => e.OfficeEquipmentId, "IX_ConnectionEquipment_OfficeEquipmentId");

            entity.Property(e => e.ConnectionEquipmentId).HasColumnName("connection_equipment_id");
            entity.Property(e => e.ConnectionEquipmentAmount).HasColumnName("connection_equipment_amount");
            entity.Property(e => e.ConnectionId).HasColumnName("connection_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.OfficeEquipmentId).HasColumnName("office_equipment_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Connection).WithMany(p => p.ConnectionEquipments)
                .HasForeignKey(d => d.ConnectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_connection");

            entity.HasOne(d => d.OfficeEquipment).WithMany(p => p.ConnectionEquipments)
                .HasForeignKey(d => d.OfficeEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_office_equipment");
        });

        modelBuilder.Entity<ConnectionTariff>(entity =>
        {
            entity.HasKey(e => e.ConnectionTariffId).HasName("PK__Connecti__7986F62E2962E692");

            entity.ToTable("ConnectionTariff");

            entity.Property(e => e.ConnectionTariffId).HasColumnName("connection_tariff_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<ConnectionsReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ConnectionsReport");

            entity.Property(e => e.AvarageConnectionPrice)
                .HasColumnType("money")
                .HasColumnName("avarage_connection_price");
            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city_name");
            entity.Property(e => e.ConnectionsCount).HasColumnName("connections_count");
            entity.Property(e => e.InternetTariffName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("internet_tariff_name");
            entity.Property(e => e.MaxConnectionPrice)
                .HasColumnType("money")
                .HasColumnName("max_connection_price");
            entity.Property(e => e.MinConnectionPrice)
                .HasColumnType("money")
                .HasColumnName("min_connection_price");
            entity.Property(e => e.MultiApartmentBuildingConnections).HasColumnName("multi_apartment_building_connections");
            entity.Property(e => e.PrivateSectorConnections).HasColumnName("private_sector_connections");
            entity.Property(e => e.SmallApartmentBuildingConnections).HasColumnName("small_apartment_building_connections");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C52E0BA81274DB0B");

            entity.ToTable("Employee", tb => tb.HasTrigger("EmployeeOfficeTrigger"));

            entity.HasIndex(e => e.PhoneNumber, "UQ__Employee__A1936A6B3F12F04C").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Employee__AB6E616404CDF810").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmployeePositionId).HasColumnName("employee_position_id");
            entity.Property(e => e.EmployeeStatusId).HasColumnName("employee_status_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.OfficeId).HasColumnName("office_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.EmployeePosition).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeePositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee_position");

            entity.HasOne(d => d.EmployeeStatus).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee_status");

            entity.HasOne(d => d.Office).WithMany(p => p.Employees)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_office");
        });

        modelBuilder.Entity<EmployeePosition>(entity =>
        {
            entity.HasKey(e => e.EmployeePositionId).HasName("PK__Employee__A6A1257C60EFC98A");

            entity.ToTable("EmployeePosition");

            entity.Property(e => e.EmployeePositionId).HasColumnName("employee_position_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EmployeePositionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_position");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<EmployeeStatus>(entity =>
        {
            entity.HasKey(e => e.EmployeeStatusId).HasName("PK__Employee__EDD287846018B3E6");

            entity.ToTable("EmployeeStatus");

            entity.Property(e => e.EmployeeStatusId).HasColumnName("employee_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EmployeeStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_status");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<EmployeesReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EmployeesReport");

            entity.Property(e => e.ConnectionsCount).HasColumnName("connections_count");
            entity.Property(e => e.DaysWithoutConnection).HasColumnName("days_without_connection");
            entity.Property(e => e.EmployeeFirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_first_name");
            entity.Property(e => e.EmployeeLastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_last_name");
            entity.Property(e => e.EmployeePosition)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_position");
            entity.Property(e => e.EmployeeStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_status");
            entity.Property(e => e.FirstConnectionDate).HasColumnName("first_connection_date");
            entity.Property(e => e.LastConnectionDate).HasColumnName("last_connection_date");
            entity.Property(e => e.OfficeAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("office_address");
            entity.Property(e => e.OfficeCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("office_city");
            entity.Property(e => e.OfficeEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("office_email");
            entity.Property(e => e.OfficePhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("office_phone");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("PK__Equipmen__197068AF7EC45C10");

            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EquipmentTypeId).HasColumnName("equipment_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.EquipmentType).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.EquipmentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_equipment_type");
        });

        modelBuilder.Entity<EquipmentReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EquipmentReport");

            entity.Property(e => e.CountConnectionsUse).HasColumnName("count_connections_use");
            entity.Property(e => e.CountOfficesHave).HasColumnName("count_offices_have");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("equipment_name");
            entity.Property(e => e.EquipmentType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("equipment_type");
            entity.Property(e => e.TotalInOffices).HasColumnName("total_in_offices");
        });

        modelBuilder.Entity<EquipmentType>(entity =>
        {
            entity.HasKey(e => e.EquipmentTypeId).HasName("PK__Equipmen__D8B1EC05651C9D4A");

            entity.ToTable("EquipmentType");

            entity.Property(e => e.EquipmentTypeId).HasColumnName("equipment_type_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EquipmentTypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("equipment_type");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<House>(entity =>
        {
            entity.HasKey(e => e.HouseId).HasName("PK__House__E24626419289811A");

            entity.ToTable("House");

            entity.Property(e => e.HouseId).HasColumnName("house_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("house_number");
            entity.Property(e => e.StreetId).HasColumnName("street_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Street).WithMany(p => p.Houses)
                .HasForeignKey(d => d.StreetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_street");
        });

        modelBuilder.Entity<InternetConnectionRequest>(entity =>
        {
            entity.HasKey(e => e.InternetConnectionRequestId).HasName("PK__Internet__AB3061E5B1D47AEA");

            entity.ToTable("InternetConnectionRequest");

            entity.HasIndex(e => e.RequestDate, "InternetConnectionRequest_request_date_IDX");

            entity.HasIndex(e => e.Number, "UQ__Internet__FD291E4145F9AB4B").IsUnique();

            entity.Property(e => e.InternetConnectionRequestId).HasColumnName("internet_connection_request_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.InternetConnectionRequestStatusId).HasColumnName("internet_connection_request_status_id");
            entity.Property(e => e.InternetTariffId).HasColumnName("internet_tariff_id");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.RequestDate).HasColumnName("request_date");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Client).WithMany(p => p.InternetConnectionRequests)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("fk_client");

            entity.HasOne(d => d.InternetConnectionRequestStatus).WithMany(p => p.InternetConnectionRequests)
                .HasForeignKey(d => d.InternetConnectionRequestStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_request_status");

            entity.HasOne(d => d.InternetTariff).WithMany(p => p.InternetConnectionRequests)
                .HasForeignKey(d => d.InternetTariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_internet_tariff");
        });

        modelBuilder.Entity<InternetConnectionRequestStatus>(entity =>
        {
            entity.HasKey(e => e.InternetConnectionRequestStatusId).HasName("PK__Internet__9CA7A241DFC511C2");

            entity.ToTable("InternetConnectionRequestStatus");

            entity.Property(e => e.InternetConnectionRequestStatusId).HasColumnName("internet_connection_request_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.InternetConnectionRequestStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("internet_connection_request_status");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<InternetTariff>(entity =>
        {
            entity.HasKey(e => e.InternetTariffId).HasName("PK__Internet__5DA1086BBE8656A4");

            entity.ToTable("InternetTariff", tb => tb.HasTrigger("InternetTariffUpdateTrigger"));

            entity.Property(e => e.InternetTariffId).HasColumnName("internet_tariff_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.InternetSpeedMbits).HasColumnName("internet_speed_mbits");
            entity.Property(e => e.InternetTariffStatusId).HasColumnName("internet_tariff_status_id");
            entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.InternetTariffStatus).WithMany(p => p.InternetTariffs)
                .HasForeignKey(d => d.InternetTariffStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tariff_status");

            entity.HasOne(d => d.LocationType).WithMany(p => p.InternetTariffs)
                .HasForeignKey(d => d.LocationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_location_type_");
        });

        modelBuilder.Entity<InternetTariffStatus>(entity =>
        {
            entity.HasKey(e => e.InternetTariffStatusId).HasName("PK__Internet__A427AF2A349ABD7A");

            entity.ToTable("InternetTariffStatus");

            entity.Property(e => e.InternetTariffStatusId)
                .ValueGeneratedNever()
                .HasColumnName("internet_tariff_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.InternetTariffStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("internet_tariff_status");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__771831EA1718521C");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.ApartmentNumber).HasColumnName("apartment_number");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.HouseId).HasColumnName("house_id");
            entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.House).WithMany(p => p.Locations)
                .HasForeignKey(d => d.HouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_house");

            entity.HasOne(d => d.LocationType).WithMany(p => p.Locations)
                .HasForeignKey(d => d.LocationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_location_type");
        });

        modelBuilder.Entity<LocationType>(entity =>
        {
            entity.HasKey(e => e.LocationTypeId).HasName("PK__Location__535FD89A63DBD566");

            entity.ToTable("LocationType");

            entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.LocationTypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location_type");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.OfficeId).HasName("PK__Office__2A196375878F0F99");

            entity.ToTable("Office");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Office__A1936A6B595321FB").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Office__AB6E616424395FF7").IsUnique();

            entity.Property(e => e.OfficeId).HasColumnName("office_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.City).WithMany(p => p.Offices)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_city_Office");
        });

        modelBuilder.Entity<OfficeEquipment>(entity =>
        {
            entity.HasKey(e => e.OfficeEquipmentId).HasName("PK__OfficeEq__05F556A58424C729");

            entity.ToTable("OfficeEquipment");

            entity.HasIndex(e => e.EquipmentId, "IX_OfficeEquipment_EquipmentId");

            entity.HasIndex(e => e.OfficeEquipmentAmount, "OfficeEquipment_office_equipment_amount_IDX");

            entity.Property(e => e.OfficeEquipmentId).HasColumnName("office_equipment_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.OfficeEquipmentAmount).HasColumnName("office_equipment_amount");
            entity.Property(e => e.OfficeId).HasColumnName("office_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Equipment).WithMany(p => p.OfficeEquipments)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_equipment");

            entity.HasOne(d => d.Office).WithMany(p => p.OfficeEquipments)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_office_");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.StreetId).HasName("PK__Street__665BB66B8FD12D0B");

            entity.ToTable("Street");

            entity.Property(e => e.StreetId).HasColumnName("street_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.StreetName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.City).WithMany(p => p.Streets)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_city_Street");
        });
    }
}
