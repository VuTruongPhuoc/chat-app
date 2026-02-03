namespace Common.Constants;

public sealed class MessageCode
{
    #region Success

    public const string Success = "SUCCESS";

    public const string LoginSuccess = "LOGIN_SUCCESS";

    public const string RegisterSuccess = "REGISTER_SUCCESS";

    public const string UpdateSuccess = "UPDATE_SUCCESS";

    public const string DeleteSuccess = "DELETE_SUCCESS";

    #endregion

    #region Error Codes

    public const string BadRequest = "BAD_REQUEST";

    public const string NotFound = "NOT_FOUND";

    public const string InvalidToken = "INVALID_TOKEN";

    public const string InternalServerError = "INTERNAL_SERVER_ERROR";

    public const string UserNotFound = "USER_NOT_FOUND";

    public const string UserNameIsRequired = "USERNAME_IS_REQUIRED";

    public const string EmailIsRequired = "EMAIL_IS_REQUIRED";

    public const string PassWordIsRequired = "PASSWORD_IS_REQUIRED";

    public const string InvalidEmailFormat = "INVALID_EMAIL_FORMAT";

    public const string UserNameAlreadyExists = "USERNAME_ALREADY_EXISTS";

    public const string EmailAlreadyExists = "EMAIL_ALREADY_EXISTS";

    #endregion
}