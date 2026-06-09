**Password Manager**

A simple C# password manager for storing and retrieving passwords from a text file.

**Features**:
- List all passwords
- Add a new password
- Delete a password
- Update a password
- Get a password by name
- Save passwords to a file
- Read passwords from a file

**Password file format**:
Each line stores one entry in the following format:

websitename=password

Example:

github=MySecretToken123

**Run the project**:
1. Make sure the .NET SDK is installed.
2. Open a terminal in the `PasswordManager` folder.
3. Run:

```bash
dotnet run
```

**In-app usage (examples)**:
- To list all passwords: choose the "list" option (or equivalent).
- To add: enter the site name and the password.
- To delete: enter the site name to remove.
- To update: enter the site name and the new password.
- To get a password: enter the site name to retrieve its value.

**Security notes**:
- This is an educational and minimal project — passwords are not stored encrypted.
- Do not use this for sensitive data in production without adding proper encryption and protections.

**Contributing**:
Contributions are welcome. Open an issue or a pull request to improve features or add encryption.

**Important files**:
- PasswordEncrypUtility.cs — encryption/decryption utilities (if present).
- passwords.txt — default storage file for entries.

