/*++

Copyright (c) 2000  Microsoft Corporation

Module Name:

    ktmtypes.h

Abstract:

    Common types for KTM exposed at both the Nt- and Win32-layer.

Revision History:

--*/

// begin_wdm begin_winnt
#ifndef _KTMTYPES_
#define _KTMTYPES_


#ifdef __cplusplus
extern "C" {
#endif

#if _MSC_VER >= 1200
#pragma warning(push)
#pragma warning(disable:4820) // padding added after data member
#endif

typedef GUID UOW, *PUOW;
typedef GUID CRM_PROTOCOL_ID, *PCRM_PROTOCOL_ID;

//
// Define the TransactionManager option values
//

#define TRANSACTION_MANAGER_VOLATILE              0x00000001
#define TRANSACTION_MANAGER_COMMIT_DEFAULT        0x00000000
#define TRANSACTION_MANAGER_COMMIT_SYSTEM_VOLUME  0x00000002
#define TRANSACTION_MANAGER_COMMIT_SYSTEM_HIVES   0x00000004
#define TRANSACTION_MANAGER_COMMIT_LOWEST         0x00000008
#define TRANSACTION_MANAGER_CORRUPT_FOR_RECOVERY  0x00000010
#define TRANSACTION_MANAGER_CORRUPT_FOR_PROGRESS  0x00000020
#define TRANSACTION_MANAGER_MAXIMUM_OPTION        0x0000003F


//
// Define the Transaction option values
//

#define TRANSACTION_DO_NOT_PROMOTE        0x00000001
#define TRANSACTION_MAXIMUM_OPTION        0x00000001


//
// Define the ResourceManager option values
//

#define RESOURCE_MANAGER_VOLATILE            0x00000001
#define RESOURCE_MANAGER_COMMUNICATION       0x00000002
#define RESOURCE_MANAGER_MAXIMUM_OPTION      0x00000003


//
// Define the RegisterProtocol option values
//

#define CRM_PROTOCOL_EXPLICIT_MARSHAL_ONLY      0x00000001
#define CRM_PROTOCOL_DYNAMIC_MARSHAL_INFO       0x00000002
#define CRM_PROTOCOL_MAXIMUM_OPTION             0x00000003


//
// Define the Enlistment option values
//

#define ENLISTMENT_SUPERIOR                  0x00000001
#define ENLISTMENT_MAXIMUM_OPTION            0x00000001


typedef ULONG NOTIFICATION_MASK;
#define TRANSACTION_NOTIFY_MASK                 0x3FFFFFFF
#define TRANSACTION_NOTIFY_PREPREPARE           0x00000001
#define TRANSACTION_NOTIFY_PREPARE              0x00000002
#define TRANSACTION_NOTIFY_COMMIT               0x00000004
#define TRANSACTION_NOTIFY_ROLLBACK             0x00000008
#define TRANSACTION_NOTIFY_PREPREPARE_COMPLETE  0x00000010
#define TRANSACTION_NOTIFY_PREPARE_COMPLETE     0x00000020
#define TRANSACTION_NOTIFY_COMMIT_COMPLETE      0x00000040
#define TRANSACTION_NOTIFY_ROLLBACK_COMPLETE    0x00000080
#define TRANSACTION_NOTIFY_RECOVER              0x00000100
#define TRANSACTION_NOTIFY_SINGLE_PHASE_COMMIT  0x00000200
#define TRANSACTION_NOTIFY_DELEGATE_COMMIT      0x00000400
#define TRANSACTION_NOTIFY_RECOVER_QUERY        0x00000800
#define TRANSACTION_NOTIFY_ENLIST_PREPREPARE    0x00001000
#define TRANSACTION_NOTIFY_LAST_RECOVER         0x00002000
#define TRANSACTION_NOTIFY_INDOUBT              0x00004000
#define TRANSACTION_NOTIFY_PROPAGATE_PULL       0x00008000
#define TRANSACTION_NOTIFY_PROPAGATE_PUSH       0x00010000
#define TRANSACTION_NOTIFY_MARSHAL              0x00020000
#define TRANSACTION_NOTIFY_ENLIST_MASK          0x00040000
#define TRANSACTION_NOTIFY_RM_DISCONNECTED      0x01000000
#define TRANSACTION_NOTIFY_TM_ONLINE            0x02000000
#define TRANSACTION_NOTIFY_COMMIT_REQUEST       0x04000000
#define TRANSACTION_NOTIFY_PROMOTE              0x08000000
#define TRANSACTION_NOTIFY_PROMOTE_NEW          0x10000000
#define TRANSACTION_NOTIFY_REQUEST_OUTCOME      0x20000000
//
//  Note that this flag is not included in the TRANSACTION_NOTIFY_MASK.
//  The reason being that KTM does not understand this flag yet. This
//  flag is strictly for the use of filter manager. In fact we mask it
//  out before enlisting in any transaction.
//
#define TRANSACTION_NOTIFY_COMMIT_FINALIZE      0x40000000 

//
// Path to the transaction manager objects in the NT
// object namespace.
//
#define TRANSACTIONMANAGER_OBJECT_PATH  L"\\TransactionManager\\"
#define TRANSACTION_OBJECT_PATH         L"\\Transaction\\"
#define ENLISTMENT_OBJECT_PATH          L"\\Enlistment\\"
#define RESOURCE_MANAGER_OBJECT_PATH    L"\\ResourceManager\\"

//
// The following three defines are here to ease the allocation
// of string buffers which are to contain a fully qualified 
// transaction manager object name, e.g., \Transaction\{GUID}
//
#define TRANSACTIONMANAGER_OBJECT_NAME_LENGTH_IN_BYTES      (sizeof(TRANSACTIONMANAGER_OBJECT_PATH)+(38*sizeof(WCHAR)))
#define TRANSACTION_OBJECT_NAME_LENGTH_IN_BYTES      (sizeof(TRANSACTION_OBJECT_PATH)+(38*sizeof(WCHAR)))
#define ENLISTMENT_OBJECT_NAME_LENGTH_IN_BYTES       (sizeof(ENLISTMENT_OBJECT_PATH)+(38*sizeof(WCHAR)))
#define RESOURCE_MANAGER_OBJECT_NAME_LENGTH_IN_BYTES (sizeof(RESOURCE_MANAGER_OBJECT_PATH)+(38*sizeof(WCHAR)))

// 
typedef struct _TRANSACTION_NOTIFICATION {
    PVOID         TransactionKey;
    ULONG         TransactionNotification;
    LARGE_INTEGER TmVirtualClock;
    ULONG         ArgumentLength;
} TRANSACTION_NOTIFICATION, *PTRANSACTION_NOTIFICATION;

typedef struct _TRANSACTION_NOTIFICATION_RECOVERY_ARGUMENT {
    GUID   EnlistmentId;
    UOW    UOW;
} TRANSACTION_NOTIFICATION_RECOVERY_ARGUMENT, *PTRANSACTION_NOTIFICATION_RECOVERY_ARGUMENT;

#define TRANSACTION_NOTIFICATION_TM_ONLINE_FLAG_IS_CLUSTERED 0x1

typedef struct _TRANSACTION_NOTIFICATION_TM_ONLINE_ARGUMENT {
    GUID TmIdentity;
    ULONG Flags;
} TRANSACTION_NOTIFICATION_TM_ONLINE_ARGUMENT, *PTRANSACTION_NOTIFICATION_TM_ONLINE_ARGUMENT;

typedef ULONG SAVEPOINT_ID, *PSAVEPOINT_ID;

typedef struct _TRANSACTION_NOTIFICATION_SAVEPOINT_ARGUMENT {
    SAVEPOINT_ID SavepointId;
} TRANSACTION_NOTIFICATION_SAVEPOINT_ARGUMENT, *PTRANSACTION_NOTIFICATION_SAVEPOINT_ARGUMENT;

typedef struct _TRANSACTION_NOTIFICATION_PROPAGATE_ARGUMENT {
    ULONG PropagationCookie;
    GUID  UOW;
    GUID  TmIdentity;
    ULONG BufferLength;
    // Bufferlength bytes of Buffer follow
} TRANSACTION_NOTIFICATION_PROPAGATE_ARGUMENT, *PTRANSACTION_NOTIFICATION_PROPAGATE_ARGUMENT;

typedef struct _TRANSACTION_NOTIFICATION_MARSHAL_ARGUMENT {
    ULONG MarshalCookie;
    GUID  UOW;
} TRANSACTION_NOTIFICATION_MARSHAL_ARGUMENT, *PTRANSACTION_NOTIFICATION_MARSHAL_ARGUMENT;

typedef TRANSACTION_NOTIFICATION_PROPAGATE_ARGUMENT TRANSACTION_NOTIFICATION_PROMOTE_ARGUMENT, *PTRANSACTION_NOTIFICATION_PROMOTE_ARGUMENT;

#define KTM_MARSHAL_BLOB_VERSION_MAJOR 1
#define KTM_MARSHAL_BLOB_VERSION_MINOR 1

#define MAX_TRANSACTION_DESCRIPTION_LENGTH  64
#define MAX_RESOURCEMANAGER_DESCRIPTION_LENGTH  64

typedef struct _KCRM_MARSHAL_HEADER {
    ULONG              VersionMajor;
    ULONG              VersionMinor;
    ULONG              NumProtocols;
    ULONG              Unused;        // for alignment purposes
} KCRM_MARSHAL_HEADER, *PKCRM_MARSHAL_HEADER, *RESTRICTED_POINTER PRKCRM_MARSHAL_HEADER;

typedef struct _KCRM_TRANSACTION_BLOB {
    UOW                UOW;
    GUID               TmIdentity;
    ULONG              IsolationLevel;
    ULONG              IsolationFlags;
    ULONG              Timeout;
    WCHAR              Description[MAX_TRANSACTION_DESCRIPTION_LENGTH];
} KCRM_TRANSACTION_BLOB, *PKCRM_TRANSACTION_BLOB, *RESTRICTED_POINTER PRKCRM_TRANSACTION_BLOB;

typedef struct _KCRM_PROTOCOL_BLOB {
    CRM_PROTOCOL_ID    ProtocolId;
    _Field_range_ (0,ULONG_MAX/2) ULONG StaticInfoLength;
    ULONG              TransactionIdInfoLength; //??? ProtocolDynamicInfoLength;
    ULONG              Unused1;        // for alignment purposes
    ULONG              Unused2;        // for alignment purposes
} KCRM_PROTOCOL_BLOB, *PKCRM_PROTOCOL_BLOB, *RESTRICTED_POINTER PRKCRM_PROTOCOL_BLOB;

#if _MSC_VER >= 1200
#pragma warning(pop)
#endif

#ifdef __cplusplus
}
#endif

#endif // _KTMTYPES_
