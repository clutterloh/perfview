
// Welcome to the TraceEvent code base. This _README.cs file is your table of contents.
// 
// -------------------------------------------------------------------------------------
// The best way to learn about the library is to look at the samples in the samples directory.
// Start with the SimpleEventSourceMonitor and SimpleEventSourceFile samples.  
// 
// -------------------------------------------------------------------------------------
// Overview of files
// 
//  Basic structure of the codebase
// 
// * Native Directories These hold native binaries needed by the library these need to be deployed along with the DLL 
//      * arm64  
//      * arm    
//      * x86  
//            Binaries present in these directories. 
//                  msdia140.dll for unmanaged symbol resolution (used by SymbolReaderModule),
//                  KernelTraceControl.dll   (used by TraceEventSession)
//
//  * Parsers       - These contain all the TraceEventParsers shipped with the library
//  * Stacks        - Logic for parsing and manipulating stack traces (either using ETW or not)
//  * Symbols       - Logic for manipulating _NT_SYMBOL_PATHS and looking up information in PDB files
//  * TraceUtilities- Generic utilities more specific to tracing (e.g. look up DLL header information)
//  * Utilities     - Generic utilities (Serialization, file I/O ...)
//
// The Main files are 
//   * TraceEvent.cs:  The most fundamental file.  Contains 'TraceEvent which represents a single event 
//      and TraceEventSource which represents a stream of such events.   Also contains the TraceEventParser
//      class that represents something that can parser particular events. 
// 
//  * TraceEventSession.cs:  A TraceEventSession presents an ETW session (something that can control
//      what events are generated by various providers and knows how to send these events various places.
// 
//  There are also some important TraceEventParsers 
// 
// * KernelTraceEventParser.cs - holds KernelTraceEventParser which represent the stream of kernel
//     events. It understands the payloads for kernel events and define a host of subclasses of
//     TraceEvent that represent them (eg ProcessTraceData, ImageLoadTraceData ...)
//     
// * ClrTraceEventSource.cs - holds CLRTraceEventParser which represent the stream of Clr events.
//     It understands the payloads for Clr events and define a host of subclasses of TraceEvent that
//     represent them (eg GCStartTraceEvent, AllocationTickTraceEvent ...)
// 
// * RegisteredTraceEventParser.cs:  holds the parser that knows how to read the OS ETW manifest 
//     database.   This parser can thus read any OS shipped ETW provider (see logman query providers)
//
// * DynamicTraceEventParser.cs: This TraceEventParser knows how to read ETW providers that dump their
//      manifests to the log file at runtime (dyanamically).    System.Diagnistics.Tracing.EventSouces
//      do this 
//
// -------------------------------------------------------------------------------------
// In addition to the code above there is a 'processes' version of ETW events call ETLX and its
// programatic interface is the TraceLog class.   This is a layer 'on top' of the code above.  
//  
// * TraceLog.cs - holds TraceLog and friends. While the raw ETW events are valuable, they really
//     need additional processing to be really useful. Things like symbolic names for addresses, various
//     links between threads, threads, modules, and eventToStack traces are really needed. This is what
//     TraceLog provides. This is likely to be the interface that most people use (when it is complete).
// 

