public enum NotificationType
{
    // --- Nhóm Tin nhắn ---
    NewMessage = 1,          // Có tin nhắn mới (Chat 1-1 hoặc Group)
    Mentioned = 2,           // Được nhắc tên (@username) trong một nhóm
    MessageReaction = 3,     // Ai đó thả tim/like vào tin nhắn của bạn

    // --- Nhóm Bạn bè ---
    FriendRequest = 10,      // Có lời mời kết bạn mới
    FriendAccepted = 11,     // Lời mời kết bạn đã được đồng ý

    // --- Nhóm Server/Phòng ---
    RoomInvitation = 20,     // Được mời vào một phòng chat/group
    ServerAnnouncement = 21, // Thông báo chung từ Admin server (nếu có server)

    // --- Nhóm Cuộc gọi ---
    MissedCall = 30          // Thông báo cuộc gọi lỡ
}