# Qontak.Crm

Unofficial Qontak .NET Library [Qontak CRM](https://www.qontak.com/)

Currently default version will be v3.1

## Installation

Coming soon!

## Supported API Section

1. ~~Company~~
2. ~~Contact~~
3. [Deal](#deal) - ongoing development
4. ~~Task~~
5. ~~Product~~
6. ~~Products Association~~
7. ~~Ticket~~
8. ~~Note~~
9. ~~Pipelines~~

Note : Strikethroughed api section meaning still waiting for development

## Usage

### Basic Usage

```cs
// get option from Configuration or just simply create a singleton
var options = Configuration.GetSection("CrmClientOptions");

// first create crm client
var crmClient = new QontakCrmClient(options);
```
 
### <a name="deal"></a> Deal service

Deal usage

```cs
// create deal service
IDealService dealService = new DealService(crmClient);

var info = await dealService.GetInfosAsync(cancellationToken);
```

Deal service contains following api(s)
1. [Create deal](#deal-create)
2. [Get template info](#deal-template-info)
3. [Get pipeline](#deal-pipeline)
4. [Get stage(s) by pipeline](#deal-stage)
5. [Update deal](#deal-update)
6. [Delete deal](#deal-delete)

#### <a name="deal-create"></a> Create Deal

Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum

#### <a name="deal-template-info"></a> Get deal template info

Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum


#### <a name="deal-pipeline"></a> Get pipeline

Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum

#### <a name="deal-stage"></a> Get Stage

Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum

#### <a name="deal-update"></a> Update deal

Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum

#### <a name="deal-delete"></a> Delete Deal

Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum