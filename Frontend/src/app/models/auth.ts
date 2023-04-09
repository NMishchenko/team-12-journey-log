export class LoginModel{
  email!: string;
  password!: string;
}

export class SignupModel{
  userName!: string;
  email!: string;
  password!: string;
  confirmPassword!: string;
}

export class JwtTokenModel{
  token!: string;
}

export class ConfirmEmailModel{
  email!: string;
  token!: string;
}

export class ResetPasswordModel{
  email!: string;
  password!: string;
  token!: string;
}
