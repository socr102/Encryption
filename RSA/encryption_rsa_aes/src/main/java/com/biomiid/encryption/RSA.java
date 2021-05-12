package com.biomiid.encryption;

import java.security.KeyFactory;
import java.security.PublicKey;
import java.security.spec.X509EncodedKeySpec;
import java.util.Base64;
import javax.crypto.Cipher;


public class RSA {
	
	public static String encrypt(String data, String publicKey) {
	    try {
	    	  Cipher cipher = Cipher.getInstance("RSA/ECB/OAEPWithSHA-1AndMGF1Padding");
              byte[] publicBytes = Base64.getDecoder().decode(publicKey.getBytes("UTF-8"));
              X509EncodedKeySpec keySpec = new X509EncodedKeySpec(publicBytes);
              KeyFactory keyFactory = KeyFactory.getInstance("RSA");
              PublicKey pubKey = keyFactory.generatePublic(keySpec);
              cipher.init(Cipher.ENCRYPT_MODE, pubKey);
   
              byte[] encryptedBytes = cipher.doFinal(data.getBytes("UTF-8"));
		      return Base64.getEncoder().encodeToString(encryptedBytes);
	    } catch (Exception e) {
	          System.out.println("Error while encrypting: " + e.toString());
	    }
	    return null;
	  }
	

}
