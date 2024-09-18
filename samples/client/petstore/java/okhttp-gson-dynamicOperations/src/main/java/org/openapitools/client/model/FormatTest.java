/*
 * OpenAPI Petstore
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


package org.openapitools.client.model;

import java.util.Objects;
import com.google.gson.TypeAdapter;
import com.google.gson.annotations.JsonAdapter;
import com.google.gson.annotations.SerializedName;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import java.io.File;
import java.io.IOException;
import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.Arrays;
import java.util.UUID;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonArray;
import com.google.gson.JsonDeserializationContext;
import com.google.gson.JsonDeserializer;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParseException;
import com.google.gson.TypeAdapterFactory;
import com.google.gson.reflect.TypeToken;
import com.google.gson.TypeAdapter;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import java.io.IOException;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.openapitools.client.JSON;

/**
 * FormatTest
 */
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", comments = "Generator version: 7.9.0-SNAPSHOT")
public class FormatTest {
  public static final String SERIALIZED_NAME_INTEGER = "integer";
  @SerializedName(SERIALIZED_NAME_INTEGER)
  private Integer integer;

  public static final String SERIALIZED_NAME_INT32 = "int32";
  @SerializedName(SERIALIZED_NAME_INT32)
  private Integer int32;

  public static final String SERIALIZED_NAME_INT64 = "int64";
  @SerializedName(SERIALIZED_NAME_INT64)
  private Long int64;

  public static final String SERIALIZED_NAME_NUMBER = "number";
  @SerializedName(SERIALIZED_NAME_NUMBER)
  private BigDecimal number;

  public static final String SERIALIZED_NAME_FLOAT = "float";
  @SerializedName(SERIALIZED_NAME_FLOAT)
  private Float _float;

  public static final String SERIALIZED_NAME_DOUBLE = "double";
  @SerializedName(SERIALIZED_NAME_DOUBLE)
  private Double _double;

  public static final String SERIALIZED_NAME_STRING = "string";
  @SerializedName(SERIALIZED_NAME_STRING)
  private String string;

  public static final String SERIALIZED_NAME_BYTE = "byte";
  @SerializedName(SERIALIZED_NAME_BYTE)
  private byte[] _byte;

  public static final String SERIALIZED_NAME_BINARY = "binary";
  @SerializedName(SERIALIZED_NAME_BINARY)
  private File binary;

  public static final String SERIALIZED_NAME_DATE = "date";
  @SerializedName(SERIALIZED_NAME_DATE)
  private LocalDate date;

  public static final String SERIALIZED_NAME_DATE_TIME = "dateTime";
  @SerializedName(SERIALIZED_NAME_DATE_TIME)
  private OffsetDateTime dateTime;

  public static final String SERIALIZED_NAME_UUID = "uuid";
  @SerializedName(SERIALIZED_NAME_UUID)
  private UUID uuid;

  public static final String SERIALIZED_NAME_PASSWORD = "password";
  @SerializedName(SERIALIZED_NAME_PASSWORD)
  private String password;

  public static final String SERIALIZED_NAME_BIG_DECIMAL = "BigDecimal";
  @SerializedName(SERIALIZED_NAME_BIG_DECIMAL)
  private BigDecimal bigDecimal;

  public FormatTest() {
  }

  public FormatTest integer(Integer integer) {
    this.integer = integer;
    return this;
  }

  /**
   * Get integer
   * minimum: 10
   * maximum: 100
   * @return integer
   */
  @javax.annotation.Nullable
  public Integer getInteger() {
    return integer;
  }

  public void setInteger(Integer integer) {
    this.integer = integer;
  }


  public FormatTest int32(Integer int32) {
    this.int32 = int32;
    return this;
  }

  /**
   * Get int32
   * minimum: 20
   * maximum: 200
   * @return int32
   */
  @javax.annotation.Nullable
  public Integer getInt32() {
    return int32;
  }

  public void setInt32(Integer int32) {
    this.int32 = int32;
  }


  public FormatTest int64(Long int64) {
    this.int64 = int64;
    return this;
  }

  /**
   * Get int64
   * @return int64
   */
  @javax.annotation.Nullable
  public Long getInt64() {
    return int64;
  }

  public void setInt64(Long int64) {
    this.int64 = int64;
  }


  public FormatTest number(BigDecimal number) {
    this.number = number;
    return this;
  }

  /**
   * Get number
   * minimum: 32.1
   * maximum: 543.2
   * @return number
   */
  @javax.annotation.Nonnull
  public BigDecimal getNumber() {
    return number;
  }

  public void setNumber(BigDecimal number) {
    this.number = number;
  }


  public FormatTest _float(Float _float) {
    this._float = _float;
    return this;
  }

  /**
   * Get _float
   * minimum: 54.3
   * maximum: 987.6
   * @return _float
   */
  @javax.annotation.Nullable
  public Float getFloat() {
    return _float;
  }

  public void setFloat(Float _float) {
    this._float = _float;
  }


  public FormatTest _double(Double _double) {
    this._double = _double;
    return this;
  }

  /**
   * Get _double
   * minimum: 67.8
   * maximum: 123.4
   * @return _double
   */
  @javax.annotation.Nullable
  public Double getDouble() {
    return _double;
  }

  public void setDouble(Double _double) {
    this._double = _double;
  }


  public FormatTest string(String string) {
    this.string = string;
    return this;
  }

  /**
   * Get string
   * @return string
   */
  @javax.annotation.Nullable
  public String getString() {
    return string;
  }

  public void setString(String string) {
    this.string = string;
  }


  public FormatTest _byte(byte[] _byte) {
    this._byte = _byte;
    return this;
  }

  /**
   * Get _byte
   * @return _byte
   */
  @javax.annotation.Nonnull
  public byte[] getByte() {
    return _byte;
  }

  public void setByte(byte[] _byte) {
    this._byte = _byte;
  }


  public FormatTest binary(File binary) {
    this.binary = binary;
    return this;
  }

  /**
   * Get binary
   * @return binary
   */
  @javax.annotation.Nullable
  public File getBinary() {
    return binary;
  }

  public void setBinary(File binary) {
    this.binary = binary;
  }


  public FormatTest date(LocalDate date) {
    this.date = date;
    return this;
  }

  /**
   * Get date
   * @return date
   */
  @javax.annotation.Nonnull
  public LocalDate getDate() {
    return date;
  }

  public void setDate(LocalDate date) {
    this.date = date;
  }


  public FormatTest dateTime(OffsetDateTime dateTime) {
    this.dateTime = dateTime;
    return this;
  }

  /**
   * Get dateTime
   * @return dateTime
   */
  @javax.annotation.Nullable
  public OffsetDateTime getDateTime() {
    return dateTime;
  }

  public void setDateTime(OffsetDateTime dateTime) {
    this.dateTime = dateTime;
  }


  public FormatTest uuid(UUID uuid) {
    this.uuid = uuid;
    return this;
  }

  /**
   * Get uuid
   * @return uuid
   */
  @javax.annotation.Nullable
  public UUID getUuid() {
    return uuid;
  }

  public void setUuid(UUID uuid) {
    this.uuid = uuid;
  }


  public FormatTest password(String password) {
    this.password = password;
    return this;
  }

  /**
   * Get password
   * @return password
   */
  @javax.annotation.Nonnull
  public String getPassword() {
    return password;
  }

  public void setPassword(String password) {
    this.password = password;
  }


  public FormatTest bigDecimal(BigDecimal bigDecimal) {
    this.bigDecimal = bigDecimal;
    return this;
  }

  /**
   * Get bigDecimal
   * @return bigDecimal
   */
  @javax.annotation.Nullable
  public BigDecimal getBigDecimal() {
    return bigDecimal;
  }

  public void setBigDecimal(BigDecimal bigDecimal) {
    this.bigDecimal = bigDecimal;
  }



  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    FormatTest formatTest = (FormatTest) o;
    return Objects.equals(this.integer, formatTest.integer) &&
        Objects.equals(this.int32, formatTest.int32) &&
        Objects.equals(this.int64, formatTest.int64) &&
        Objects.equals(this.number, formatTest.number) &&
        Objects.equals(this._float, formatTest._float) &&
        Objects.equals(this._double, formatTest._double) &&
        Objects.equals(this.string, formatTest.string) &&
        Arrays.equals(this._byte, formatTest._byte) &&
        Objects.equals(this.binary, formatTest.binary) &&
        Objects.equals(this.date, formatTest.date) &&
        Objects.equals(this.dateTime, formatTest.dateTime) &&
        Objects.equals(this.uuid, formatTest.uuid) &&
        Objects.equals(this.password, formatTest.password) &&
        Objects.equals(this.bigDecimal, formatTest.bigDecimal);
  }

  @Override
  public int hashCode() {
    return Objects.hash(integer, int32, int64, number, _float, _double, string, Arrays.hashCode(_byte), binary, date, dateTime, uuid, password, bigDecimal);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class FormatTest {\n");
    sb.append("    integer: ").append(toIndentedString(integer)).append("\n");
    sb.append("    int32: ").append(toIndentedString(int32)).append("\n");
    sb.append("    int64: ").append(toIndentedString(int64)).append("\n");
    sb.append("    number: ").append(toIndentedString(number)).append("\n");
    sb.append("    _float: ").append(toIndentedString(_float)).append("\n");
    sb.append("    _double: ").append(toIndentedString(_double)).append("\n");
    sb.append("    string: ").append(toIndentedString(string)).append("\n");
    sb.append("    _byte: ").append(toIndentedString(_byte)).append("\n");
    sb.append("    binary: ").append(toIndentedString(binary)).append("\n");
    sb.append("    date: ").append(toIndentedString(date)).append("\n");
    sb.append("    dateTime: ").append(toIndentedString(dateTime)).append("\n");
    sb.append("    uuid: ").append(toIndentedString(uuid)).append("\n");
    sb.append("    password: ").append("*").append("\n");
    sb.append("    bigDecimal: ").append(toIndentedString(bigDecimal)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }


  public static HashSet<String> openapiFields;
  public static HashSet<String> openapiRequiredFields;

  static {
    // a set of all properties/fields (JSON key names)
    openapiFields = new HashSet<String>();
    openapiFields.add("integer");
    openapiFields.add("int32");
    openapiFields.add("int64");
    openapiFields.add("number");
    openapiFields.add("float");
    openapiFields.add("double");
    openapiFields.add("string");
    openapiFields.add("byte");
    openapiFields.add("binary");
    openapiFields.add("date");
    openapiFields.add("dateTime");
    openapiFields.add("uuid");
    openapiFields.add("password");
    openapiFields.add("BigDecimal");

    // a set of required properties/fields (JSON key names)
    openapiRequiredFields = new HashSet<String>();
    openapiRequiredFields.add("number");
    openapiRequiredFields.add("byte");
    openapiRequiredFields.add("date");
    openapiRequiredFields.add("password");
  }

  /**
   * Validates the JSON Element and throws an exception if issues found
   *
   * @param jsonElement JSON Element
   * @throws IOException if the JSON Element is invalid with respect to FormatTest
   */
  public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      if (jsonElement == null) {
        if (!FormatTest.openapiRequiredFields.isEmpty()) { // has required fields but JSON element is null
          throw new IllegalArgumentException(String.format("The required field(s) %s in FormatTest is not found in the empty JSON string", FormatTest.openapiRequiredFields.toString()));
        }
      }

      Set<Map.Entry<String, JsonElement>> entries = jsonElement.getAsJsonObject().entrySet();
      // check to see if the JSON string contains additional fields
      for (Map.Entry<String, JsonElement> entry : entries) {
        if (!FormatTest.openapiFields.contains(entry.getKey())) {
          throw new IllegalArgumentException(String.format("The field `%s` in the JSON string is not defined in the `FormatTest` properties. JSON: %s", entry.getKey(), jsonElement.toString()));
        }
      }

      // check to make sure all required properties/fields are present in the JSON string
      for (String requiredField : FormatTest.openapiRequiredFields) {
        if (jsonElement.getAsJsonObject().get(requiredField) == null) {
          throw new IllegalArgumentException(String.format("The required field `%s` is not found in the JSON string: %s", requiredField, jsonElement.toString()));
        }
      }
        JsonObject jsonObj = jsonElement.getAsJsonObject();
      if ((jsonObj.get("string") != null && !jsonObj.get("string").isJsonNull()) && !jsonObj.get("string").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `string` to be a primitive type in the JSON string but got `%s`", jsonObj.get("string").toString()));
      }
      if ((jsonObj.get("uuid") != null && !jsonObj.get("uuid").isJsonNull()) && !jsonObj.get("uuid").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `uuid` to be a primitive type in the JSON string but got `%s`", jsonObj.get("uuid").toString()));
      }
      if (!jsonObj.get("password").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `password` to be a primitive type in the JSON string but got `%s`", jsonObj.get("password").toString()));
      }
  }

  public static class CustomTypeAdapterFactory implements TypeAdapterFactory {
    @SuppressWarnings("unchecked")
    @Override
    public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
       if (!FormatTest.class.isAssignableFrom(type.getRawType())) {
         return null; // this class only serializes 'FormatTest' and its subtypes
       }
       final TypeAdapter<JsonElement> elementAdapter = gson.getAdapter(JsonElement.class);
       final TypeAdapter<FormatTest> thisAdapter
                        = gson.getDelegateAdapter(this, TypeToken.get(FormatTest.class));

       return (TypeAdapter<T>) new TypeAdapter<FormatTest>() {
           @Override
           public void write(JsonWriter out, FormatTest value) throws IOException {
             JsonObject obj = thisAdapter.toJsonTree(value).getAsJsonObject();
             elementAdapter.write(out, obj);
           }

           @Override
           public FormatTest read(JsonReader in) throws IOException {
             JsonElement jsonElement = elementAdapter.read(in);
             validateJsonElement(jsonElement);
             return thisAdapter.fromJsonTree(jsonElement);
           }

       }.nullSafe();
    }
  }

  /**
   * Create an instance of FormatTest given an JSON string
   *
   * @param jsonString JSON string
   * @return An instance of FormatTest
   * @throws IOException if the JSON string is invalid with respect to FormatTest
   */
  public static FormatTest fromJson(String jsonString) throws IOException {
    return JSON.getGson().fromJson(jsonString, FormatTest.class);
  }

  /**
   * Convert an instance of FormatTest to an JSON string
   *
   * @return JSON string
   */
  public String toJson() {
    return JSON.getGson().toJson(this);
  }
}

