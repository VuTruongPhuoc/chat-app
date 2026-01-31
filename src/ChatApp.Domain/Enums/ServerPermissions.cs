namespace ChatApp.Domain.Enums;

[Flags]
public enum ServerPermissions : int
{
    None = 0,

    // Nhóm Quản trị
    Administrator = 1 << 0,      // 1: Toàn quyền (vượt qua mọi check)
    ManageServer = 1 << 1,       // 2: Sửa tên/ảnh Server
    ManageRoles = 1 << 2,        // 4: Tạo/Gán Role cho Member

    // Nhóm Thành viên
    KickMembers = 1 << 3,        // 8: Đuổi người
    CreateInvite = 1 << 4,       // 16: Tạo link mời người khác

    // Nhóm Chat
    SendMessages = 1 << 5,       // 32: Quyền chat cơ bản
    AttachFiles = 1 << 6,        // 64: Gửi ảnh/file
    ManageMessages = 1 << 7      // 128: Xóa tin nhắn của người khác
}
