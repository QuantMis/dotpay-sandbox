# About
Dotpay is a sandbox payment gateway developed using C# and .NET framework.

# Overview
Dotpay consist of multiple backend services such as:
1. MerchantService
2. KYCService
3. DeveloperAuthService 

# Project Architecture 
![architecture-v1](images/architecture-v1.jpeg)

# Services Specification
## MerchantService
| Method | Request URI | Use Case |
|--------|---------------------------------|--------------------------------|
| POST   | `api/merchant/register`         | Register new merchant          |
| PUT    | `api/merchant/register`         | Update merchant                |
| GET    | `api/merchant/{merchantId}`     | Query merchant information     |
| GET    | `api/merchant`                  | Query all merchant information |

## KYCService
| Method | Request URI | Use Case |
|--------|---------------------------------|--------------------------------|
| POST   | `api/kyc/upload`                | Submit KYC documents           |
| GET    | `api/kyc/status/{merchantId}`   | Query KYC status               |
| GET    | `api/kyc/verify/{merchantId}`   | Approve or reject kyc status   |

## DeveloperAuthService
| Method | Request URI | Use Case |
|--------|---------------------------------|--------------------------------|
| GET    | `api/dev-auth/api-keys`         | Query API Keys for merchant    |
| POST   | `api/dev-auth/api-keys`         | Create API keys for merchant   |
| DELETE | `api/dev-auth/api-keys/{keyId}` | Revoke API Keys                |


# Motivation
1. Learning the ins and outs of payment gateway
2. Practice to implement industry level code standard 
3. Implement industry level cicd workflow
4. Learning product development

# Consideration
- Good DX
- CICD
- Harness value from monorepo 
- Ensure codebase is industry standard


