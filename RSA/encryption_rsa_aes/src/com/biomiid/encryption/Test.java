package com.biomiid.encryption;

public class Test {

	public static void main(String[] args) {
		String data ="Bonjour monsieur du corbeau!";
		String aesKey = new RandomString(32).nextString();
		System.out.println("Encrypted  data :"+AES.encrypt(data,aesKey));

	}

}
