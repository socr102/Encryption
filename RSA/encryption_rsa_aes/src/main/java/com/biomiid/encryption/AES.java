package com.biomiid.encryption;



public class AES {

  private static final String SALT = "fa402db659644c9c881cde92013b2901";
  
  private static String factoryInstance = "PBKDF2WithHmacSHA1";
  private static String cipherInstance = "AES/CBC/PKCS5PADDING";
  private static String secretKeyType = "AES";
  private static byte[] ivCode = new byte[16];
 
  public static String encrypt(String data, String aesKey) {
    
    return null;
  }
  
  
}

