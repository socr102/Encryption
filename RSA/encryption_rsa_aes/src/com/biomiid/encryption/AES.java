package com.biomiid.encryption;

import javax.crypto.Cipher;
import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.PBEKeySpec;
import javax.crypto.spec.SecretKeySpec;
import java.nio.charset.StandardCharsets;
import java.security.spec.KeySpec;
import java.util.Base64;
import java.security.SecureRandom;
 
public class AES {

  private static final String SALT = "fa402db659644c9c881cde92013b2901";
 
  public static String encrypt(String data, String aesKey) {
    try {
		  byte[] iv = new byte[16];
		  SecureRandom rnd = new SecureRandom();
		  rnd.nextBytes(iv);
	      SecretKeyFactory factory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA256");
	      KeySpec spec = new PBEKeySpec(aesKey.toCharArray(), SALT.getBytes(), 65536, 256);
	      SecretKey tmp = factory.generateSecret(spec);
	      SecretKeySpec secretKey = new SecretKeySpec(tmp.getEncoded(), "AES");
 
      	  Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
 
	      IvParameterSpec ivspec = new IvParameterSpec(iv);
	      cipher.init(Cipher.ENCRYPT_MODE, secretKey, ivspec);
	      return Base64.getEncoder().encodeToString(cipher.doFinal(data.getBytes(StandardCharsets.UTF_8)));
    } catch (Exception e) {
          System.out.println("Error while encrypting: " + e.toString());
    }
    return null;
  }
}

