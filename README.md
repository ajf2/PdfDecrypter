# PdfDecrypter

Simple command line app for decrypting password-protected PDF files, if you know the password. Built using iText7, which does all the hard work better than the other packages I tried (included in the source).

Usage:

```
PdfDecrypter.exe <path-to-pdf-file>
```

Enter the correct password and it'll produce a `.dec.pdf` file in the same location as the input.

TODO:
- Enter an incorrect password and it'll throw an exception. It should display a message and take input for a new password attempt.
- Pressing backspace adds `\b` to the password string instead of removing the most recently added character.
- There may be problems with other keys e.g. Home/End/Cursors.
- It won't work if your PDF file's name doesn't end in `.pdf`.
- It probably throws an exception if your file is not a PDF file.
