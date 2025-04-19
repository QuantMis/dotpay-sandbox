# MerchantService API & Event Specification

## POST /api/merchant/register
**Use Case**: Register a new merchant and onboard into the platform.
**Headers:**
```json
{
  "Content-Type": "application/json",
  "Idempotency-Key": "string (optional, used to prevent duplicate submissions)"
}
```
**Request Body:**
```json
{
  "business_name": "string (required, maxLength: 100)",
  "email": "string (required, email format, unique)",
  "business_registration_number": "string (required, alphanumeric, unique)",
  "business_type": "enum ['sole_proprietorship', 'partnership', 'private_limited']",
  "website": "string (optional, valid URL)",
  "phone_number": "string (E.164 format)",
  "country": "string (ISO 3166-1 alpha-2)",
  "currency": "string (ISO 4217, e.g. MYR)",
  "default_statement_descriptor": "string (maxLength: 22, appears on customer bank statement)",
  "contact_person": {
    "full_name": "string (required)",
    "email": "string (required, email format)",
    "phone_number": "string (E.164 format)"
  }
}
```
**Response Body:**
```json
{
  "id": "UUID",
  "status": "string (e.g. 'pending_kyc')",
  "created_at": "datetime",
  "live_mode": "boolean"
}
```
**Emits Event**: `MerchantRegistered`
- **Trigger**: When a new merchant is successfully registered
- **Topic**: `merchant.events`
- **Payload:**
```json
{
  "merchant_id": "UUID",
  "email": "string",
  "status": "string",
  "created_at": "datetime"
}
```
---
## PUT /api/merchant/register
**Use Case**: Update existing merchant's details.
**Headers:**
```json
{
  "Authorization": "Bearer <token>",
  "Content-Type": "application/json"
}
```
**Request Body:**
```json
{
  "merchant_id": "UUID (required)",
  "business_name": "string (optional)",
  "email": "string (optional)",
  "website": "string (optional, valid URL)",
  "phone_number": "string (optional, E.164 format)",
  "default_statement_descriptor": "string (optional, maxLength: 22)"
}
```
**Response Body:**
```json
{
  "success": "boolean",
  "updated_at": "datetime"
}
```
**Emits Event**: `MerchantUpdated`
- **Trigger**: When a merchant profile is updated
- **Topic**: `merchant.events`
- **Payload:**
```json
{
  "merchant_id": "UUID",
  "updated_fields": [
    "string"
  ],
  "updated_at": "datetime"
}
```
---
## GET /api/merchant/{merchantId}
**Use Case**: Retrieve a specific merchant’s information.
**Headers:**
```json
{
  "Authorization": "Bearer <token>"
}
```
**Response Body:**
```json
{
  "merchant_id": "UUID",
  "business_name": "string",
  "email": "string",
  "status": "string",
  "created_at": "datetime"
}
```
---
## GET /api/merchant
**Use Case**: Query all merchants (paginated).
**Headers:**
```json
{
  "Authorization": "Bearer <admin token>"
}
```
**Request Body:**
```json
{
  "page": "int (optional, default: 1)",
  "per_page": "int (optional, default: 20)"
}
```
**Response Body:**
```json
{
  "data": [
    {
      "merchant_id": "UUID",
      "business_name": "string",
      "email": "string",
      "status": "string"
    }
  ],
  "meta": {
    "total": "int",
    "page": "int",
    "per_page": "int"
  }
}
```
---
