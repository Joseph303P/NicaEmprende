﻿using System;
using System.Net;
using System.Net.Mail;

public class Email
{
    // Se utiliza para enviar un correo electrónico al usuario
    public void Enviar(string correo, string token)
    {
        Correo(correo, token);
    }

    // Configura el correo electrónico y lo envía usando el protocolo SMTP
    void Correo(string correo_receptor, string token)
    {
        string correo_emisor = "paravideos404@gmail.com";
        string clave_emisor = "xixz xzhp rdeu cqdg"; 

        MailAddress receptor = new(correo_receptor);
        MailAddress emisor = new(correo_emisor);

        MailMessage email = new(emisor, receptor);
        
            email.Subject = "InnoMasketss: Activación de cuenta";
            email.Body = @"<!DOCTYPE html>
                           <html>
                           <head>
                               <title>Activación de cuenta</title>
                           </head>
                           <body>
                               <h2>Activación de cuenta</h2>
                               <p>Para activar su cuenta, haga clic en el siguiente enlace:</p>
                               <a href='https://localhost:7131/Cuenta/Token?valor=" + token + "'>Activar cuenta</a></body> </html>";

            email.IsBodyHtml = true;

                SmtpClient smtp = new();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587; // Usamos el puerto correcto para TLS
                smtp.EnableSsl = true; // Asegúrate de que esté habilitado el uso de SSL/TLS
                smtp.Credentials = new NetworkCredential(correo_emisor, clave_emisor);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Timeout = 10000; // Tiempo de espera opcional

                try
                {
            smtp.Send(email);
                }
                catch (SmtpException)
                {
                    throw;
                }
            
        
    }
}
