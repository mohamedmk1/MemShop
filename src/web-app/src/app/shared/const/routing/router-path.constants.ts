export class RouterPaths {

  static DASHBOARD = {
    BASE: {
      label: 'Dashboard',
      path: 'dashboard',
    },
  };

  static SUPPLIERS = {
    BASE: {
      label: 'Fournisseur',
      path: '/suppliers',
    },
    SUPPLIER_ADD: {
      label: 'Ajouter un fournisseur',
      path: '/suppliers/add',
    },
    SUPPLIER_EDIT: {
      label: 'Modifier un fournisseur',
      path: '/suppliers/edit/:id',
    }
  };

  static ARTICLES = {
    BASE: {
      label: 'Articles',
      path: '/products',
    },
    CATEGORY: {
      label: 'Catégories',
      path: '/categories',
    },
    CATEGORY_ADD: {
      label: 'Ajouter une catégorie',
      path: '/categories/add',
    },
    CATEGORY_EDIT: {
      label: 'Modifier une catégorie',
      path: '/categories/edit/:id',
    },
    PRODUCT: {
      label: 'Produits',
      path: '/products',
    },
    PRODUCT_ADD: {
      label: 'Ajouter un produit',
      path: '/products/add',
    },
    PRODUCT_EDIT: {
      label: 'Modifier un produit',
      path: '/products/edit/:id',
    }
  };

  static ORDERS = {
    BASE: {
      label: 'Bons de commande',
      path: '/orders',
    },
    ORDER_ADD: {
      label: 'Créer un nouveau bon de commande',
      path: '/orders/add',
    },
    ORDER_EDIT: {
      label: 'Modifier un bon de commande',
      path: '/orders/edit/:id',
    }
  };

  static PATHMATCH = 'full';
}
