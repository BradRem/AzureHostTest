This app endeavors to show how the CSLA data portal can
be hosted in Azure and be accessed from a Windows Form
application. Currently, the data portal in this project,
when running locally in the Azure emulator or if
actually deployed to Azure throws an exception:

>System.ServiceModel.Security.SecurityNegotiationException:
>Secure channel cannot be opened because security negotiation with the remote endpoint has failed. This may be due to absent or incorrectly specified EndpointIdentity in the EndpointAddress used to create the channel. Please verify the EndpointIdentity specified or implied by the EndpointAddress correctly identifies the remote endpoint. 
>
>Inner exception:
>System.ServiceModel.FaultException: The message with Action 'http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue' cannot be processed at the receiver, due to a ContractFilter mismatch at the EndpointDispatcher. This may be because of either a contract mismatch (mismatched Actions between sender and receiver) or a binding/security mismatch between the sender and the receiver.  Check that sender and receiver have the same contract and the same binding (including security requirements, e.g. Message, Transport, None).

WARNING: This solution assumes you have installed and
configured the Windows Azure SDK (including the compute
and storage emulators) on your development workstation.

WARNING: Visual Studio must be run as administrator to
run the solution in Debug mode.

Included as a Nuget package is the CSLA.NET framework. 
CSLA .NET is a software development framework that helps 
you build a reusable, maintainable object-oriented 
business layer for your app.

##The Solution Files:##

This solution contains two groups of files. The three projects
prefixed with "NonCSLA" demonstrates a standard WCF service
that is accessed by a WinForms application. These project
do not contain anyCSLA. The NonCSLA Debug/Release configurations
will compile and run these projects.  The NonCSLA projects
were created to demonstrate that wsHttpBinding does indeed work
and to compare with the CSLA-based projects and settings.

The other project is the CSLA-based projects that do not
yet work in Azure. These are compiled from the CSLA Debug/Release
configurations.

The AzureHost project is the Windows Azure project where
the Azure roles are defined and configured.

The WebRole1 project hosts the data portal. It is configured
to run in the Windows Azure compute simulator. If you have
a Windows Azure account, you can deploy it to the actual
Windows Azure cloud-based servers. The data portal is WCF
based.

The DataAccess, DataAccess.Mock, and Library.Net projects
contain the data access layers and business objects.

The WindowsFormsUI is the WinForm application that uses
the Library.NET business objects to communicate with the
Azure hosted data portal.

##Running locally:##

One way to test locally is to select AzureHost as the
startup and then "Start without Debugging". A browser will
appear. The two addresses in the WindowsFormUI app.config 
should be set to the proper local address such as 
http://127.0.0.1:81/WcfPortal.svc

Next, set the WindowsFormsUI application as the startup 
project and "Start with Debugging". The application will 
start and will throw an exception as soon as it attempts
to connect to the data portal. This is the bug that should
be fixed.

The WebRole1 project can be Published to Azure. Once 
published, the two addresses for the WcfPortal.svc in the 
WindowsFormsUI project should be updated to reference the
Azure website.

FYI: The initial commit of this project demonstrates the 
application's usage in a non-Azure environment.
